using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Domain.Entities
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string ExternalReference { get; set; } = string.Empty;

        public bool HasFaceTemplate { get; set; }

        public bool HasFingerprintTemplate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
