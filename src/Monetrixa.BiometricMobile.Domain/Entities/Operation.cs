using Monetrixa.BiometricMobile.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Domain.Entities
{
    public class Operation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string CustomerId { get; set; } = string.Empty;

        public OperationType Type { get; set; }

        public decimal Amount { get; set; }

        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
