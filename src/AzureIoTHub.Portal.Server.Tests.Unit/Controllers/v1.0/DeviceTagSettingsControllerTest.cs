﻿// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Server.Tests.Unit.Controllers.V10
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AzureIoTHub.Portal.Server.Controllers.V10;
    using AzureIoTHub.Portal.Server.Services;
    using AzureIoTHub.Portal.Shared.Models.V10.Device;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class DeviceTagSettingsControllerTest
    {
        private MockRepository mockRepository;

        //private Mock<IDeviceTagMapper> mockDeviceTagMapper;
        //private Mock<ITableClientFactory> mockTableClientFactory;
        //private Mock<TableClient> mockDeviceTagTableClient;
        private Mock<IDeviceTagService> mockDeviceTagService;
        private Mock<ILogger<DeviceTagSettingsController>> mockLogger;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            //this.mockDeviceTagMapper = this.mockRepository.Create<IDeviceTagMapper>();
            //this.mockTableClientFactory = this.mockRepository.Create<ITableClientFactory>();
            //this.mockDeviceTagTableClient = this.mockRepository.Create<TableClient>();
            this.mockDeviceTagService = this.mockRepository.Create<IDeviceTagService>();
            this.mockLogger = this.mockRepository.Create<ILogger<DeviceTagSettingsController>>();
        }

        private DeviceTagSettingsController CreateDeviceTagSettingsController()
        {
            return new DeviceTagSettingsController(
                this.mockLogger.Object,
                //this.mockDeviceTagMapper.Object,
                //this.mockTableClientFactory.Object,
                this.mockDeviceTagService.Object
           );
        }

        [Test]
        public async Task PostShouldCreateNewEntity()
        {
            // Arrange
            var deviceTagSettingsController = this.CreateDeviceTagSettingsController();

            var tag = new DeviceTag
            {
                Name = "testName",
                Label = "testLabel",
                Required = true,
                Searchable = true
            };

            _ = this.mockDeviceTagService.Setup(c => c.UpdateTags(It.IsAny<List<DeviceTag>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await deviceTagSettingsController.Post(new List<DeviceTag>(new[] { tag }));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<OkResult>(result);
            this.mockDeviceTagService.VerifyAll();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void GetShouldReturnAList()
        {
            // Arrange
            var deviceTagSettingsController = this.CreateDeviceTagSettingsController();

            _ = mockDeviceTagService.Setup(x => x.GetAllTags()).Returns(new DeviceTag[10].ToList());

            // Act
            var response = deviceTagSettingsController.Get();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsAssignableFrom<OkObjectResult>(response.Result);
            var okResponse = response.Result as OkObjectResult;

            Assert.AreEqual(200, okResponse.StatusCode);

            Assert.IsNotNull(okResponse.Value);
            var result = okResponse.Value as IEnumerable<DeviceTag>;
            Assert.AreEqual(10, result.Count());

            this.mockDeviceTagService.VerifyAll();
            this.mockRepository.VerifyAll();
        }
    }
}