using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Domain.Enums
{
    public enum BiometricDecisionMode
    {
        FaceOnly = 1,
        FingerprintOnly = 2,
        FaceAndFingerprint = 3,
        FaceOrFingerprint = 4
    }
}
