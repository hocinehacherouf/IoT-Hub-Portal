// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Shared.Models
{
    public interface IDeviceModel
    {
        /// <summary>
        /// The device model identifier.
        /// </summary>
        public string ModelId { get; set; }

        /// <summary>
        /// The device model image Url.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The device model name.
        /// </summary>
        [Required(ErrorMessage = "The device model name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// The device model description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A value indicating whether this instance is builtin.
        /// </summary>
        public bool IsBuiltin { get; set; }

        /// <summary>
        /// A value indicating whether the device model supports LoRa features.
        /// </summary>
        public bool SupportLoRaFeatures { get; }

        /// <summary>
        /// Labels
        /// </summary>
        public List<LabelDto> Labels { get; set; }
    }
}
