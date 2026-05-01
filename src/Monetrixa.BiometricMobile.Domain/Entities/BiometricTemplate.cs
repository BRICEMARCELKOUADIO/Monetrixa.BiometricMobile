using Monetrixa.BiometricMobile.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Domain.Entities
{
    public class BiometricTemplate
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string CustomerId { get; set; } = string.Empty;

        public BiometricType Type { get; set; }

        public byte[] TemplateData { get; set; } = Array.Empty<byte>();

        public string Provider { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
