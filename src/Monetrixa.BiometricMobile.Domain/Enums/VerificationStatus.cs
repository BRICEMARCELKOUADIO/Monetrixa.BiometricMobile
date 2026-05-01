using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Domain.Enums
{
    public enum VerificationStatus
    {
        Pending = 1,
        Success = 2,
        Failed = 3,
        Cancelled = 4,
        Error = 5
    }
}
