using Monetrixa.BiometricMobile.Application.Results;
using Monetrixa.BiometricMobile.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Application.Interfaces
{
    public interface IBiometricOrchestrator
    {
        Task<IReadOnlyList<BiometricCaptureResult>> EnrollAsync(
            string customerId,
            IReadOnlyList<BiometricType> requiredTypes,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<BiometricVerificationResult>> VerifyAsync(
            string customerId,
            BiometricDecisionMode decisionMode,
            IReadOnlyDictionary<BiometricType, byte[]> referenceTemplates,
            CancellationToken cancellationToken = default);
    }
}
