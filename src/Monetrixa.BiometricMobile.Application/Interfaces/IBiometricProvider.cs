using Monetrixa.BiometricMobile.Application.Results;
using Monetrixa.BiometricMobile.Domain.Enums;

namespace Monetrixa.BiometricMobile.Application.Interfaces
{
    public interface IBiometricProvider
    {
        BiometricType Type { get; }

        string ProviderName { get; }

        Task<BiometricInitializationResult> InitializeAsync(
            CancellationToken cancellationToken = default);

        Task<BiometricCaptureResult> EnrollAsync(
            string customerId,
            CancellationToken cancellationToken = default);

        Task<BiometricVerificationResult> VerifyAsync(
            string customerId,
            byte[] referenceTemplate,
            CancellationToken cancellationToken = default);
    }
}
