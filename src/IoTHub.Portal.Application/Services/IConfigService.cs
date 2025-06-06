// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Application.Services
{
    using Configuration = Microsoft.Azure.Devices.Configuration;

    public interface IConfigService
    {
        Task<IEnumerable<Configuration>> GetIoTEdgeConfigurations();

        Task<IEnumerable<Configuration>> GetDevicesConfigurations();

        Task<string> RollOutDeviceModelConfiguration(string modelId, Dictionary<string, object> desiredProperties);

        Task DeleteDeviceModelConfigurationByConfigurationNamePrefix(string configurationNamePrefix);

        Task<string> RollOutEdgeModelConfiguration(IoTEdgeModel edgeModel);

        Task<string> RollOutDeviceConfiguration(string modelId, Dictionary<string, object> desiredProperties, string configurationId, Dictionary<string, string> targetTags, int priority = 0);

        Task<Configuration> GetConfigItem(string id);

        Task DeleteConfiguration(string configId);

        Task<int> GetFailedDeploymentsCount();

        Task<List<IoTEdgeModule>> GetConfigModuleList(string modelId);

        Task<List<EdgeModelSystemModule>> GetModelSystemModule(string modelId);

        Task<List<IoTEdgeRoute>> GetConfigRouteList(string modelId);

        Task<IEnumerable<IoTEdgeModule>> GetPublicEdgeModules();
    }
}
