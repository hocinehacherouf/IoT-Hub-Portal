// Copyright (c) CGI France. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace IoTHub.Portal.Client.Services
{
    public class ClipboardService
    {
        private readonly IJSRuntime jsRuntime;

        public ClipboardService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public ValueTask WriteTextAsync(string text)
        {
            return this.jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }
}
