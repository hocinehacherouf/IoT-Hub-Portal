// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Server.Tests.Unit.Validators
{
    using System;
    using AzureIoTHub.Portal.Client.Validators;
    using AzureIoTHub.Portal.Models.v10;
    using NUnit.Framework;

    internal class DeviceModelValidatorTests
    {
        [Test]
        public void ValidateValidModel()
        {

            // Arrange
            var standardModelValidator = new DeviceModelValidator();
            var deviceModel = new DeviceModel()
            {
                Name = Guid.NewGuid().ToString(),
            };

            // Act
            var standardModelValidation = standardModelValidator.Validate(deviceModel);

            // Assert
            Assert.IsTrue(standardModelValidation.IsValid);
            Assert.AreEqual(0, standardModelValidation.Errors.Count);
        }

        [Test]
        public void ValidateMissingNameShouldReturnError()
        {
            // Arrange
            var standardModelValidator = new DeviceModelValidator();
            var deviceModel = new DeviceModel();

            // Act
            var standardModelValidation = standardModelValidator.Validate(deviceModel);

            // Assert
            Assert.IsFalse(standardModelValidation.IsValid);
            Assert.AreEqual(standardModelValidation.Errors[0].ErrorMessage, $"Model name is required.");
        }
    }
}
