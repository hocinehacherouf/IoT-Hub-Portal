﻿// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Server.Mappers
{
    using System;
    using AzureIoTHub.Portal.Server.Managers;
    using AzureIoTHub.Portal.Shared.Models.V10.Device;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Devices.Shared;

    public class DeviceTwinMapper : IDeviceTwinMapper<DeviceListItem, DeviceDetails>
    {
        private readonly IDeviceModelImageManager deviceModelImageManager;

        public DeviceTwinMapper(IDeviceModelImageManager deviceModelImageManager)
        {
            this.deviceModelImageManager = deviceModelImageManager;
        }

        public DeviceDetails CreateDeviceDetails(Twin twin)
        {
            var modelId = Helpers.DeviceHelper.RetrieveTagValue(twin, nameof(DeviceDetails.ModelId));

            return new DeviceDetails
            {
                DeviceID = twin.DeviceId,
                ModelId = modelId,
                DeviceName = Helpers.DeviceHelper.RetrieveTagValue(twin, nameof(DeviceDetails.DeviceName)),
                ImageUrl = this.deviceModelImageManager.ComputeImageUri(modelId),
                IsConnected = twin.ConnectionState == DeviceConnectionState.Connected,
                IsEnabled = twin.Status == DeviceStatus.Enabled,
                StatusUpdatedTime = twin.StatusUpdatedTime.GetValueOrDefault(DateTime.MinValue),
                LocationCode = Helpers.DeviceHelper.RetrieveTagValue(twin, nameof(DeviceDetails.LocationCode)),
                AssetId = Helpers.DeviceHelper.RetrieveTagValue(twin, nameof(DeviceDetails.AssetId))
            };
        }

        public DeviceListItem CreateDeviceListItem(Twin twin)
        {
            return new DeviceListItem
            {
                DeviceID = twin.DeviceId,
                IsConnected = twin.ConnectionState == DeviceConnectionState.Connected,
                IsEnabled = twin.Status == DeviceStatus.Enabled,
                StatusUpdatedTime = twin.StatusUpdatedTime.GetValueOrDefault(DateTime.MinValue),
                DeviceName = Helpers.DeviceHelper.RetrieveTagValue(twin, nameof(DeviceListItem.DeviceName)),
                ImageUrl = this.deviceModelImageManager.ComputeImageUri(Helpers.DeviceHelper.RetrieveTagValue(twin, nameof(DeviceDetails.ModelId))),
                SupportLoRaFeatures = bool.Parse(Helpers.DeviceHelper.RetrieveTagValue(twin, nameof(DeviceListItem.SupportLoRaFeatures)) ?? "false")
            };
        }

        public void UpdateTwin(Twin twin, DeviceDetails item)
        {
            // Update the twin properties
            Helpers.DeviceHelper.SetTagValue(twin, nameof(item.DeviceName), item.DeviceName);
            Helpers.DeviceHelper.SetTagValue(twin, nameof(item.LocationCode), item.LocationCode);
            Helpers.DeviceHelper.SetTagValue(twin, nameof(item.AssetId), item.AssetId);
            Helpers.DeviceHelper.SetTagValue(twin, nameof(item.ModelId), item.ModelId);
        }
    }
}