// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Application.Services
{
    public interface IDevicePropertyService
    {
        Task<IEnumerable<DevicePropertyValue>> GetProperties(string deviceId);

        Task SetProperties(string deviceId, IEnumerable<DevicePropertyValue> devicePropertyValues);
    }
}
