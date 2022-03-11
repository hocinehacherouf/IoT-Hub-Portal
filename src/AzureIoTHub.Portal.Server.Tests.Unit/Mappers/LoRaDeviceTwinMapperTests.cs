// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Server.Tests.Unit.Mappers
{
    using AzureIoTHub.Portal.Server.Helpers;
    using AzureIoTHub.Portal.Server.Managers;
    using AzureIoTHub.Portal.Server.Mappers;
    using AzureIoTHub.Portal.Shared.Models.V10.LoRaWAN.LoRaDevice;
    using Microsoft.Azure.Devices.Shared;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class LoRaDeviceTwinMapperTests
    {
        private MockRepository mockRepository;

        private Mock<IDeviceModelImageManager> mockDeviceModelImageManager;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDeviceModelImageManager = this.mockRepository.Create<IDeviceModelImageManager>();
        }

        private LoRaDeviceTwinMapper CreateLoRaDeviceTwinMapper()
        {
            return new LoRaDeviceTwinMapper(
                this.mockDeviceModelImageManager.Object);
        }

        [Test]
        public void CreateDeviceDetailsStateUnderTestExpectedBehavior()
        {
            // Arrange
            var loRaDeviceTwinMapper = this.CreateLoRaDeviceTwinMapper();
            var twin = new Twin(Guid.NewGuid().ToString());
            var modelId = Guid.NewGuid().ToString();

            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.ModelId), modelId);
            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.DeviceName), Guid.NewGuid().ToString());

            twin.Tags["assetId"] = Guid.NewGuid().ToString();
            twin.Tags["locationCode"] = Guid.NewGuid().ToString();
            var tagsNames = new List<string>() { "assetId", "locationCode" };

            twin.Properties.Desired[nameof(LoRaDeviceDetails.AppEUI)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.AppKey)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.SensorDecoder)] = Guid.NewGuid().ToString();

            var expectedModelImageUri = $"https://fake.local/{modelId}";

            _ = this.mockDeviceModelImageManager.Setup(c => c.ComputeImageUri(It.Is<string>(x => x == modelId)))
                .Returns(expectedModelImageUri);

            // Act
            var result = loRaDeviceTwinMapper.CreateDeviceDetails(twin, tagsNames);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(twin.DeviceId, result.DeviceID);
            Assert.AreEqual(modelId, result.ModelId);
            Assert.AreEqual(DeviceHelper.RetrieveTagValue(twin, nameof(LoRaDeviceDetails.DeviceName)), result.DeviceName);

            foreach (var tagName in tagsNames)
            {
                Assert.AreEqual(DeviceHelper.RetrieveTagValue(twin, tagName), result.Tags[tagName]);
            }

            Assert.AreEqual(expectedModelImageUri, result.ImageUrl);

            Assert.AreEqual(twin.Properties.Desired[nameof(LoRaDeviceDetails.AppEUI)].ToString(), result.AppEUI);
            Assert.AreEqual(twin.Properties.Desired[nameof(LoRaDeviceDetails.AppKey)].ToString(), result.AppKey);
            Assert.AreEqual(twin.Properties.Desired[nameof(LoRaDeviceDetails.SensorDecoder)].ToString(), result.SensorDecoder);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public void CreateDeviceDetailsNullTagListExpectedBehavior()
        {
            // Arrange
            var loRaDeviceTwinMapper = this.CreateLoRaDeviceTwinMapper();
            var twin = new Twin(Guid.NewGuid().ToString());
            var modelId = Guid.NewGuid().ToString();

            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.ModelId), modelId);
            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.DeviceName), Guid.NewGuid().ToString());

            List<string> tagsNames = null;

            twin.Properties.Desired[nameof(LoRaDeviceDetails.AppEUI)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.AppKey)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.SensorDecoder)] = Guid.NewGuid().ToString();

            var expectedModelImageUri = $"https://fake.local/{modelId}";

            _ = this.mockDeviceModelImageManager.Setup(c => c.ComputeImageUri(It.Is<string>(x => x == modelId)))
                .Returns(expectedModelImageUri);

            // Act
            var result = loRaDeviceTwinMapper.CreateDeviceDetails(twin, tagsNames);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(twin.DeviceId, result.DeviceID);
            Assert.AreEqual(modelId, result.ModelId);
            Assert.AreEqual(DeviceHelper.RetrieveTagValue(twin, nameof(LoRaDeviceDetails.DeviceName)), result.DeviceName);

            Assert.IsEmpty(result.Tags);

            Assert.AreEqual(expectedModelImageUri, result.ImageUrl);

            Assert.AreEqual(twin.Properties.Desired[nameof(LoRaDeviceDetails.AppEUI)].ToString(), result.AppEUI);
            Assert.AreEqual(twin.Properties.Desired[nameof(LoRaDeviceDetails.AppKey)].ToString(), result.AppKey);
            Assert.AreEqual(twin.Properties.Desired[nameof(LoRaDeviceDetails.SensorDecoder)].ToString(), result.SensorDecoder);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public void CreateDeviceListItemStateUnderTestExpectedBehavior()
        {
            // Arrange
            var loRaDeviceTwinMapper = this.CreateLoRaDeviceTwinMapper();
            var twin = new Twin(Guid.NewGuid().ToString());
            var modelId = Guid.NewGuid().ToString();

            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.ModelId), modelId);
            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.DeviceName), Guid.NewGuid().ToString());

            var expectedModelImageUri = $"https://fake.local/{modelId}";

            _ = this.mockDeviceModelImageManager.Setup(c => c.ComputeImageUri(It.Is<string>(x => x == modelId)))
                .Returns(expectedModelImageUri);

            // Act
            var result = loRaDeviceTwinMapper.CreateDeviceListItem(twin, null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(twin.DeviceId, result.DeviceID);
            Assert.AreEqual(DeviceHelper.RetrieveTagValue(twin, nameof(LoRaDeviceDetails.DeviceName)), result.DeviceName);

            Assert.AreEqual(expectedModelImageUri, result.ImageUrl);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public void CreateDeviceListItemWithTagsExpectedBehavior()
        {
            // Arrange
            var loRaDeviceTwinMapper = this.CreateLoRaDeviceTwinMapper();
            var twin = new Twin(Guid.NewGuid().ToString());
            var modelId = Guid.NewGuid().ToString();
            var tags = new List<string> { "tag0", "tag01" };

            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.ModelId), modelId);
            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.DeviceName), Guid.NewGuid().ToString());

            var expectedModelImageUri = $"https://fake.local/{modelId}";

            _ = this.mockDeviceModelImageManager.Setup(c => c.ComputeImageUri(It.Is<string>(x => x == modelId)))
                .Returns(expectedModelImageUri);

            // Act
            var result = loRaDeviceTwinMapper.CreateDeviceListItem(twin, tags);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(twin.DeviceId, result.DeviceID);
            Assert.AreEqual(DeviceHelper.RetrieveTagValue(twin, nameof(LoRaDeviceDetails.DeviceName)), result.DeviceName);
            Assert.IsNotNull(result.Tags);
            Assert.AreEqual(result.Tags.Count, tags.Count);

            Assert.AreEqual(expectedModelImageUri, result.ImageUrl);

            this.mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateTwinStateUnderTestExpectedBehavior()
        {
            // Arrange
            var loRaDeviceTwinMapper = this.CreateLoRaDeviceTwinMapper();
            var twin = new Twin(Guid.NewGuid().ToString());

            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.ModelId), Guid.NewGuid().ToString());
            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.DeviceName), Guid.NewGuid().ToString());

            twin.Tags["assetId"] = Guid.NewGuid().ToString();
            twin.Tags["locationCode"] = Guid.NewGuid().ToString();
            var tagsNames = new List<string>() { "assetId", "locationCode" };

            twin.Properties.Desired[nameof(LoRaDeviceDetails.AppEUI)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.AppKey)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.SensorDecoder)] = Guid.NewGuid().ToString();

            var item = new LoRaDeviceDetails
            {
                DeviceID = twin.DeviceId,
                DeviceName = Guid.NewGuid().ToString(),
                ModelId = Guid.NewGuid().ToString(),
                AppEUI = Guid.NewGuid().ToString(),
                AppKey = Guid.NewGuid().ToString(),
                SensorDecoder = Guid.NewGuid().ToString(),
                Tags = new()
                {
                    { "assetId", Guid.NewGuid().ToString() },
                    { "locationCode", Guid.NewGuid().ToString() }
                },
                UseOTAA = true,
            };

            // Act
            loRaDeviceTwinMapper.UpdateTwin(twin, item);

            // Assert
            Assert.AreEqual(item.DeviceID, twin.DeviceId);
            Assert.AreEqual(item.ModelId, DeviceHelper.RetrieveTagValue(twin, nameof(LoRaDeviceDetails.ModelId)));
            Assert.AreEqual(item.DeviceName, DeviceHelper.RetrieveTagValue(twin, nameof(LoRaDeviceDetails.DeviceName)));

            foreach (var tagName in tagsNames)
            {
                Assert.AreEqual(item.Tags[tagName], DeviceHelper.RetrieveTagValue(twin, tagName));
            }

            Assert.AreEqual(item.AppEUI, twin.Properties.Desired[nameof(LoRaDeviceDetails.AppEUI)].ToString());
            Assert.AreEqual(item.AppKey, twin.Properties.Desired[nameof(LoRaDeviceDetails.AppKey)].ToString());
            Assert.AreEqual(item.SensorDecoder, twin.Properties.Desired[nameof(LoRaDeviceDetails.SensorDecoder)].ToString());

            this.mockRepository.VerifyAll();
        }

        [Test]
        public void UpdateTwinUseOTAAIsFalseExpectedBehavior()
        {
            // Arrange
            var loRaDeviceTwinMapper = this.CreateLoRaDeviceTwinMapper();
            var twin = new Twin(Guid.NewGuid().ToString());

            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.ModelId), Guid.NewGuid().ToString());
            DeviceHelper.SetTagValue(twin, nameof(LoRaDeviceDetails.DeviceName), Guid.NewGuid().ToString());

            twin.Tags["assetId"] = Guid.NewGuid().ToString();
            twin.Tags["locationCode"] = Guid.NewGuid().ToString();
            var tagsNames = new List<string>() { "assetId", "locationCode" };

            twin.Properties.Desired[nameof(LoRaDeviceDetails.NwkSKey)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.AppSKey)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.DevAddr)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.GatewayID)] = Guid.NewGuid().ToString();
            twin.Properties.Desired[nameof(LoRaDeviceDetails.SensorDecoder)] = Guid.NewGuid().ToString();

            var item = new LoRaDeviceDetails
            {
                DeviceID = twin.DeviceId,
                DeviceName = Guid.NewGuid().ToString(),
                ModelId = Guid.NewGuid().ToString(),
                AppSKey = Guid.NewGuid().ToString(),
                NwkSKey = Guid.NewGuid().ToString(),
                DevAddr = Guid.NewGuid().ToString(),
                GatewayID = Guid.NewGuid().ToString(),
                SensorDecoder = Guid.NewGuid().ToString(),
                Tags = new()
                {
                    { "assetId", Guid.NewGuid().ToString() },
                    { "locationCode", Guid.NewGuid().ToString() }
                },
                UseOTAA = false,
            };

            // Act
            loRaDeviceTwinMapper.UpdateTwin(twin, item);

            // Assert
            Assert.AreEqual(item.DeviceID, twin.DeviceId);
            Assert.AreEqual(item.ModelId, DeviceHelper.RetrieveTagValue(twin, nameof(LoRaDeviceDetails.ModelId)));
            Assert.AreEqual(item.DeviceName, DeviceHelper.RetrieveTagValue(twin, nameof(LoRaDeviceDetails.DeviceName)));

            foreach (var tagName in tagsNames)
            {
                Assert.AreEqual(item.Tags[tagName], DeviceHelper.RetrieveTagValue(twin, tagName));
            }

            Assert.AreEqual(item.NwkSKey, twin.Properties.Desired[nameof(LoRaDeviceDetails.NwkSKey)].ToString());
            Assert.AreEqual(item.AppSKey, twin.Properties.Desired[nameof(LoRaDeviceDetails.AppSKey)].ToString());
            Assert.AreEqual(item.DevAddr, twin.Properties.Desired[nameof(LoRaDeviceDetails.DevAddr)].ToString());
            Assert.AreEqual(item.GatewayID, twin.Properties.Desired[nameof(LoRaDeviceDetails.GatewayID)].ToString());
            Assert.AreEqual(item.SensorDecoder, twin.Properties.Desired[nameof(LoRaDeviceDetails.SensorDecoder)].ToString());

            this.mockRepository.VerifyAll();
        }
    }
}