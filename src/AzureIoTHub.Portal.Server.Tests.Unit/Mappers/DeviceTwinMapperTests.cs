// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Server.Tests.Unit.Mappers
{
    using System;
    using System.Collections.Generic;
    using AzureIoTHub.Portal.Server.Extensions;
    using AzureIoTHub.Portal.Server.Factories;
    using AzureIoTHub.Portal.Server.Helpers;
    using AzureIoTHub.Portal.Server.Managers;
    using AzureIoTHub.Portal.Server.Mappers;
    using AzureIoTHub.Portal.Shared.Models.v10.Device;
    using Microsoft.Azure.Devices.Shared;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class DeviceTwinMapperTests
    {
        private MockRepository mockRepository;

        private Mock<IDeviceModelImageManager> mockDeviceModelImageManager;
        private Mock<IDeviceModelCommandsManager> mockDeviceModelCommandsManager;
        private Mock<ITableClientFactory> mockTableClientFactory;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDeviceModelImageManager = this.mockRepository.Create<IDeviceModelImageManager>();
            this.mockDeviceModelCommandsManager = this.mockRepository.Create<IDeviceModelCommandsManager>();
            this.mockTableClientFactory = this.mockRepository.Create<ITableClientFactory>();
        }

        private DeviceTwinMapper CreateDeviceTwinMapper()
        {
            return new DeviceTwinMapper(
                this.mockDeviceModelImageManager.Object);
        }

        [Test]
        public void CreateDeviceDetailsStateUnderTestExpectedBehavior()
        {
            // Arrange
            var deviceTwinMapper = this.CreateDeviceTwinMapper();
            var twin = new Twin
            {
                DeviceId = Guid.NewGuid().ToString()
            };

            twin.Tags[nameof(DeviceDetails.ModelId).ToCamelCase()] = "000-000-001";

            twin.Tags["assetId"] = Guid.NewGuid().ToString();
            twin.Tags["locationCode"] = Guid.NewGuid().ToString();
            var tagsNames = new List<string>() { "assetId", "locationCode" };

            twin.Properties.Reported["DevAddr"] = Guid.NewGuid().ToString();

            this.mockDeviceModelImageManager.Setup(c => c.ComputeImageUri(It.Is<string>(c => c.Equals("000-000-001", StringComparison.OrdinalIgnoreCase))))
                .Returns("http://fake.local/000-000-001")
                .Verifiable();

            // Act
            var result = deviceTwinMapper.CreateDeviceDetails(twin, tagsNames);

            // Assert
            Assert.IsNotNull(result);

            Assert.IsFalse(result.IsConnected);
            Assert.IsFalse(result.IsEnabled);

            Assert.AreEqual(twin.Tags[nameof(DeviceDetails.ModelId).ToCamelCase()].ToString(), result.ModelId);

            foreach (var tagName in tagsNames)
            {
                Assert.AreEqual(twin.Tags[tagName.ToCamelCase()].ToString(), result.Tags[tagName]);
            }

            Assert.AreEqual("http://fake.local/000-000-001", result.ImageUrl);
            Assert.AreEqual(DateTime.MinValue, result.StatusUpdatedTime);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public void CreateDeviceDetailsNullTagListExpectedBehavior()
        {
            // Arrange
            var deviceTwinMapper = this.CreateDeviceTwinMapper();
            var twin = new Twin
            {
                DeviceId = Guid.NewGuid().ToString()
            };

            twin.Tags[nameof(DeviceDetails.ModelId).ToCamelCase()] = "000-000-001";

            List<string> tagsNames = null;

            twin.Properties.Reported["DevAddr"] = Guid.NewGuid().ToString();

            this.mockDeviceModelImageManager.Setup(c => c.ComputeImageUri(It.Is<string>(c => c.Equals("000-000-001", StringComparison.OrdinalIgnoreCase))))
                .Returns("http://fake.local/000-000-001")
                .Verifiable();

            // Act
            var result = deviceTwinMapper.CreateDeviceDetails(twin, tagsNames);

            // Assert
            Assert.IsNotNull(result);

            Assert.IsFalse(result.IsConnected);
            Assert.IsFalse(result.IsEnabled);

            Assert.AreEqual(twin.Tags[nameof(DeviceDetails.ModelId).ToCamelCase()].ToString(), result.ModelId);

            Assert.IsEmpty(result.Tags);

            Assert.AreEqual("http://fake.local/000-000-001", result.ImageUrl);
            Assert.AreEqual(DateTime.MinValue, result.StatusUpdatedTime);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public void CreateDeviceListItemStateUnderTestExpectedBehavior()
        {
            // Arrange
            var deviceTwinMapper = this.CreateDeviceTwinMapper();

            this.mockDeviceModelImageManager.Setup(c => c.ComputeImageUri(It.Is<string>(c => c.Equals("000-000-001", StringComparison.OrdinalIgnoreCase))))
                .Returns("http://fake.local/000-000-001")
                .Verifiable();

            var twin = new Twin
            {
                DeviceId = Guid.NewGuid().ToString()
            };

            twin.Tags[nameof(DeviceDetails.ModelId).ToCamelCase()] = "000-000-001";

            // Act
            var result = deviceTwinMapper.CreateDeviceListItem(twin);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(twin.DeviceId, result.DeviceID);
            Assert.AreEqual("http://fake.local/000-000-001", result.ImageUrl);
            Assert.IsFalse(result.IsConnected);
            Assert.IsFalse(result.IsEnabled);

            Assert.AreEqual(DateTime.MinValue, result.StatusUpdatedTime);

            this.mockRepository.VerifyAll();
        }

        public void CreateDeviceListItemNullTagListExpectedBehavior()
        {
            // Arrange
            var deviceTwinMapper = this.CreateDeviceTwinMapper();

            var twin = new Twin
            {
                DeviceId = Guid.NewGuid().ToString()
            };

            twin.Tags[nameof(DeviceDetails.ModelId).ToCamelCase()] = "000-000-001";

            List<string> tagsNames = null;

            twin.Properties.Reported["DevAddr"] = Guid.NewGuid().ToString();

            this.mockDeviceModelImageManager.Setup(c => c.ComputeImageUri(It.Is<string>(c => c.Equals("000-000-001", StringComparison.OrdinalIgnoreCase))))
                .Returns("http://fake.local/000-000-001")
                .Verifiable();

            // Act
            var result = deviceTwinMapper.CreateDeviceDetails(twin, tagsNames);

            // Assert
            Assert.IsNotNull(result);

            Assert.IsFalse(result.IsConnected);
            Assert.IsFalse(result.IsEnabled);

            Assert.AreEqual(twin.Tags[nameof(DeviceDetails.ModelId).ToCamelCase()].ToString(), result.ModelId);

            Assert.IsEmpty(result.Tags);

            Assert.AreEqual("http://fake.local/000-000-001", result.ImageUrl);
            Assert.AreEqual(DateTime.MinValue, result.StatusUpdatedTime);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateTwinStateUnderTestExpectedBehavior()
        {
            // Arrange
            var deviceTwinMapper = this.CreateDeviceTwinMapper();
            var twin = new Twin();
            var item = new DeviceDetails
            {
                ModelId = Guid.NewGuid().ToString(),
                Tags = new()
                {
                    { "assetId", Guid.NewGuid().ToString() },
                    { "locationCode", Guid.NewGuid().ToString() }
                }
            };

            DeviceHelper.SetTagValue(twin, nameof(item.ModelId), item.ModelId);

            twin.Tags["assetId"] = Guid.NewGuid().ToString();
            twin.Tags["locationCode"] = Guid.NewGuid().ToString();
            var tagsNames = new List<string>() { "assetId", "locationCode" };

            // Act
            deviceTwinMapper.UpdateTwin(twin, item);

            // Assert
            Assert.AreEqual(item.ModelId, twin.Tags[nameof(DeviceDetails.ModelId).ToCamelCase()].ToString());

            foreach (var tagName in tagsNames)
            {
                Assert.AreEqual(item.Tags[tagName], DeviceHelper.RetrieveTagValue(twin, tagName));
            }

            this.mockRepository.VerifyAll();
        }
    }
}