// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Infrastructure.Mappers
{
    public class EdgeDeviceMapper : IEdgeDeviceMapper
    {
        private readonly IDeviceModelImageManager deviceModelImageManager;

        public EdgeDeviceMapper(IDeviceModelImageManager deviceModelImageManager)
        {
            this.deviceModelImageManager = deviceModelImageManager;
        }

        public IoTEdgeListItem CreateEdgeDeviceListItem(Twin deviceTwin)
        {
            return new IoTEdgeListItem()
            {
                DeviceId = deviceTwin?.DeviceId,
                DeviceName = DeviceHelper.RetrieveTagValue(deviceTwin!, nameof(IoTEdgeDevice.DeviceName)),
                Status = deviceTwin?.Status.ToString(),
                NbDevices = DeviceHelper.RetrieveConnectedDeviceCount(deviceTwin!),
                Image = this.deviceModelImageManager
                    .GetDeviceModelImageAsync(
                        DeviceHelper.RetrieveTagValue(deviceTwin!, nameof(IoTEdgeDevice.ModelId))!).Result
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceTwin"></param>
        /// <param name="deviceTwinWithModules"></param>
        /// <param name="nbConnectedDevice"></param>
        /// <param name="lastConfiguration"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public IoTEdgeDevice CreateEdgeDevice(Twin deviceTwin, Twin deviceTwinWithModules, int nbConnectedDevice, ConfigItem lastConfiguration, IEnumerable<string> tags)
        {
            var customTags = new Dictionary<string, string>();

            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    customTags.Add(tag, DeviceHelper.RetrieveTagValue(deviceTwin, tag)!);
                }
            }

            return new IoTEdgeDevice()
            {
                DeviceId = deviceTwin?.DeviceId,
                Status = deviceTwin?.Status?.ToString(),
                Scope = deviceTwin?.DeviceScope,
                ConnectionState = deviceTwin?.ConnectionState?.ToString(),
                ModelId = DeviceHelper.RetrieveTagValue(deviceTwin!, nameof(IoTEdgeDevice.ModelId)),
                DeviceName = DeviceHelper.RetrieveTagValue(deviceTwin!, nameof(IoTEdgeDevice.DeviceName)),
                NbDevices = nbConnectedDevice,
                NbModules = DeviceHelper.RetrieveNbModuleCount(deviceTwinWithModules, deviceTwin?.DeviceId!),
                RuntimeResponse = DeviceHelper.RetrieveRuntimeResponse(deviceTwinWithModules),
                Modules = DeviceHelper.RetrieveModuleList(deviceTwinWithModules),
                LastDeployment = lastConfiguration,
                Tags = customTags,
                Image = this.deviceModelImageManager.GetDeviceModelImageAsync(DeviceHelper.RetrieveTagValue(deviceTwin!, nameof(IoTEdgeDevice.ModelId))!).Result,
            };
        }
    }
}
