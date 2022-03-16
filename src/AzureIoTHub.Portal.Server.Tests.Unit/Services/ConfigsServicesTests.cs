// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Server.Tests.Unit.Services
{
    using AzureIoTHub.Portal.Server.Services;
    using Microsoft.Azure.Devices;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [TestFixture]
    public class ConfigsServicesTests
    {
        private MockRepository mockRepository;

        private Mock<RegistryManager> mockRegistryManager;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockRegistryManager = this.mockRepository.Create<RegistryManager>();
        }

        private ConfigService CreateConfigsServices()
        {
            return new ConfigService(this.mockRegistryManager.Object);
        }

        [Test]
        public async Task GetIoTEdgeConfigsShouldReturnModulesConfigurations()
        {
            // Arrange
            var configsServices = this.CreateConfigsServices();
            var iotEdgeConfiguration = new Configuration("bbb");

            iotEdgeConfiguration.Content.ModulesContent.Add("test", new Dictionary<string, object>());
            _ = this.mockRegistryManager.Setup(c => c.GetConfigurationsAsync(It.Is<int>(x => x == 0)))
                .ReturnsAsync(new[]
                {
                    new Configuration("aaa"),
                    iotEdgeConfiguration
                });

            // Act
            var result = await configsServices.GetIoTEdgeConfigurations();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("bbb", result.Single().Id);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetDevicesConfigsShouldReturnDeviceTwinConfigurations()
        {
            // Arrange
            var configsServices = this.CreateConfigsServices();
            var iotEdgeConfiguration = new Configuration("bbb");

            iotEdgeConfiguration.Content.ModulesContent.Add("test", new Dictionary<string, object>());
            _ = this.mockRegistryManager.Setup(c => c.GetConfigurationsAsync(It.Is<int>(x => x == 0)))
                .ReturnsAsync(new[]
                {
                    new Configuration("aaa"),
                    iotEdgeConfiguration
                });

            // Act
            var result = await configsServices.GetDevicesConfigurations();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("aaa", result.Single().Id);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task GetConfigItemStateUnderTestExpectedBehavior()
        {
            // Arrange
            var configsServices = this.CreateConfigsServices();
            var id = "aaa";
            _ = this.mockRegistryManager.Setup(c => c.GetConfigurationAsync(It.Is<string>(x => x == id)))
                .ReturnsAsync(new Configuration(id));

            // Act
            var result = await configsServices.GetConfigItem(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            this.mockRepository.VerifyAll();
        }

        [TestCase("aaa", "aaa")]
        [TestCase("AAA", "aaa")]
        [TestCase("AAA AAA", "aaa-aaa")]
        public async Task RolloutDeviceConfigurationStateUnderTestExpectedBehavior(string deviceType, string configurationPrefix)
        {
            // Arrange
            var configsServices = this.CreateConfigsServices();
            var desiredProperties = new Dictionary<string, object>
            {
                { "prop1", "value1" }
            };
            Configuration newConfiguration = null;
            var modelId = Guid.NewGuid().ToString();

            _ = this.mockRegistryManager.Setup(c => c.GetConfigurationsAsync(It.IsAny<int>()))
                .ReturnsAsync(Array.Empty<Configuration>());

            _ = this.mockRegistryManager.Setup(c => c.AddConfigurationAsync(It.Is<Configuration>(x => x.Id.StartsWith(configurationPrefix))))
                .Callback((Configuration conf) => newConfiguration = conf)
                .ReturnsAsync((Configuration conf) => conf);

            // Act
            await configsServices.RolloutDeviceConfiguration(modelId, deviceType, desiredProperties);

            // Assert
            Assert.IsNotNull(newConfiguration);
            Assert.IsTrue(newConfiguration.Id.StartsWith(configurationPrefix, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(0, newConfiguration.Content.ModulesContent.Count);
            Assert.AreEqual(0, newConfiguration.Content.ModuleContent.Count);
            Assert.AreEqual(1, newConfiguration.Content.DeviceContent.Count);
            Assert.AreEqual(desiredProperties, newConfiguration.Content.DeviceContent);
            Assert.AreEqual($"tags.modelId = '{modelId}'", newConfiguration.TargetCondition);
            Assert.AreEqual(0, newConfiguration.Priority);

            this.mockRepository.VerifyAll();
            this.mockRegistryManager.Verify(c => c.GetConfigurationsAsync(It.IsAny<int>()), Times.Once());

        }

        [TestCase("aaa", "aaa")]
        [TestCase("AAA", "aaa")]
        [TestCase("AAA AAA", "aaa-aaa")]
        public async Task WhenConfigurationExistsRolloutDeviceConfigurationShouldRemoveIt(string deviceType, string configurationPrefix)
        {
            // Arrange
            var configsServices = this.CreateConfigsServices();
            var desirectProperties = new Dictionary<string, object>
            {
                { "prop1", "value1" }
            };
            Configuration newConfiguration;
            var suffix = Guid.NewGuid().ToString();
            var modelId = Guid.NewGuid().ToString();

            _ = this.mockRegistryManager.Setup(c => c.GetConfigurationsAsync(It.IsAny<int>()))
                .ReturnsAsync(new Configuration[]
                {
                    new Configuration($"{configurationPrefix}-{suffix}"),
                    new Configuration($"null-{suffix}")
                });

            _ = this.mockRegistryManager.Setup(c => c.AddConfigurationAsync(It.Is<Configuration>(x => x.Id.StartsWith(configurationPrefix))))
                .Callback((Configuration conf) => newConfiguration = conf)
                .ReturnsAsync((Configuration conf) => conf);

            _ = this.mockRegistryManager.Setup(c => c.RemoveConfigurationAsync(It.Is<string>(x => x == $"{configurationPrefix}-{suffix}")))
                .Returns(Task.CompletedTask);

            // Act
            await configsServices.RolloutDeviceConfiguration(modelId, deviceType, desirectProperties);

            // Assert
            this.mockRegistryManager.Verify(c => c.GetConfigurationsAsync(It.IsAny<int>()), Times.Once());
            this.mockRegistryManager.Verify(c => c.RemoveConfigurationAsync(It.IsAny<string>()), Times.Once());
        }
    }
}