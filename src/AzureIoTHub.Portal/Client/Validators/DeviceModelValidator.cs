﻿// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Client.Validators
{
    using AzureIoTHub.Portal.Shared.Models.V10.DeviceModel;
    using FluentValidation;

    public class DeviceModelValidator : AbstractValidator<DeviceModel>
    {
        public DeviceModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}