using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Domain.Entities
{
    public class AuditLog
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Action { get; set; } = string.Empty;

        public string EntityName { get; set; } = string.Empty;

        public string EntityId { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
