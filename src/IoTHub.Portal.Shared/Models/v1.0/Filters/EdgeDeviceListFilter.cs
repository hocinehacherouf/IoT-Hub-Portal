// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Shared.Models.v10.Filters
{
    public class EdgeDeviceListFilter : PaginationFilter
    {
        public string Keyword { get; set; } = default!;

        public bool? IsEnabled { get; set; }

        public string ModelId { get; set; } = default!;

        public List<string> Labels { get; set; } = new();
    }
}
