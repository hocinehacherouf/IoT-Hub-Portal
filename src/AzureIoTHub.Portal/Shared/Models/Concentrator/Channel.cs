﻿// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace AzureIoTHub.Portal.Shared.Models.Concentrator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Channel
    {
        public bool? Enable { get; set; }

        public int Freq { get; set; }

        public int Radio { get; set; }

        public int If { get; set; }

        public int Bandwidth { get; set; }

        public int Spread_factor { get; set; }
    }
}