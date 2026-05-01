using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Application.Results
{
    public class BiometricInitializationResult
    {
        public bool IsSuccess { get; set; }

        public string ProviderName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string RawResponse { get; set; } = string.Empty;
    }
}
