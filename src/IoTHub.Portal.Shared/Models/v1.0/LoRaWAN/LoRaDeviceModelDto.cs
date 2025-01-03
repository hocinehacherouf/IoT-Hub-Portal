// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Models.v10.LoRaWAN
{
    /// <summary>
    /// LoRa Device model.
    /// </summary>
    public class LoRaDeviceModelDto : LoRaDeviceBase, IDeviceModel
    {
        /// <summary>
        /// The device model identifier.
        /// </summary>
        public string ModelId { get; set; } = default!;

        /// <summary>
        /// The device model image Url.
        /// </summary>
        public string Image { get; set; } = default!;

        /// <summary>
        /// The device model name.
        /// </summary>
        [Required(ErrorMessage = "The device model name is required.")]
        public string Name { get; set; } = default!;

        /// <summary>
        /// The device model description.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// A value indicating whether this instance is builtin.
        /// </summary>
        public bool IsBuiltin { get; set; }

        /// <summary>
        /// A value indicating whether the LoRa features is supported on this model.
        /// </summary>
        public bool SupportLoRaFeatures { get; } = true;

        /// <summary>
        /// A value indicating whether the device uses OTAA to authenticate to LoRaWAN network. Otherwise ABP.
        /// Default is true.
        /// </summary>
        [DefaultValue(true)]
        public bool UseOTAA { get; set; }

        /// <summary>
        /// Allows disabling the downstream (cloud to device) for a device.
        /// By default downstream messages are enabled.
        /// </summary>
        [DefaultValue(true)]
        public bool? Downlink { get; set; }

        /// <summary>
        /// Labels
        /// </summary>
        public List<LabelDto> Labels { get; set; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="LoRaDeviceModelDto"/> class.
        /// </summary>
        /// <param name="from">The device model taht the LoRa Device model should herit.</param>
        public LoRaDeviceModelDto(IDeviceModel from)
        {
            ArgumentNullException.ThrowIfNull(from);

            ModelId = from.ModelId;
            Name = from.Name;
            Description = from.Description;
            IsBuiltin = from.IsBuiltin;
            Image = from.Image;
            UseOTAA = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoRaDeviceModelDto"/> class.
        /// </summary>
        public LoRaDeviceModelDto()
        {
            ClassType = ClassType.A;
            Downlink = true;
            PreferredWindow = 1;
            Deduplication = DeduplicationMode.None;
            ABPRelaxMode = true;
        }
    }
}
