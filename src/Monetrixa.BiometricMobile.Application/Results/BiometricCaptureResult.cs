using Monetrixa.BiometricMobile.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Application.Results
{
    public class BiometricCaptureResult
    {
        public bool IsSuccess { get; set; }

        public BiometricType Type { get; set; }

        public byte[] TemplateData { get; set; } = Array.Empty<byte>();

        public string ProviderName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string RawResponse { get; set; } = string.Empty;
    }
}
