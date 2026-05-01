using Monetrixa.BiometricMobile.Application.Interfaces;
using Monetrixa.BiometricMobile.Application.Results;
using Monetrixa.BiometricMobile.Domain.Enums;

namespace Monetrixa.BiometricMobile.Infrastructure.Biometrics.Fingerprint;

public class TrustFingerprintBiometricProvider : IBiometricProvider
{
    public BiometricType Type => BiometricType.Fingerprint;

    public string ProviderName => "TrustFingerprint Mock Provider";

    public Task<BiometricInitializationResult> InitializeAsync(
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new BiometricInitializationResult
        {
            IsSuccess = true,
            ProviderName = ProviderName,
            Message = "Fingerprint SDK mock initialized successfully."
        });
    }

    public Task<BiometricCaptureResult> EnrollAsync(
        string customerId,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new BiometricCaptureResult
        {
            IsSuccess = true,
            Type = BiometricType.Fingerprint,
            ProviderName = ProviderName,
            TemplateData = [50, 60, 70, 80],
            Message = $"Fingerprint template enrolled for customer {customerId}."
        });
    }

    public Task<BiometricVerificationResult> VerifyAsync(
        string customerId,
        byte[] referenceTemplate,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new BiometricVerificationResult
        {
            IsSuccess = true,
            Type = BiometricType.Fingerprint,
            Status = VerificationStatus.Success,
            Score = 94.2,
            ProviderName = ProviderName,
            Message = $"Fingerprint verification successful for customer {customerId}."
        });
    }
}