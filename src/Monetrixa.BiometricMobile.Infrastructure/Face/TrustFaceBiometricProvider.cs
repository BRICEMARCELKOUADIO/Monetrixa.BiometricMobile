using Monetrixa.BiometricMobile.Application.Interfaces;
using Monetrixa.BiometricMobile.Application.Results;
using Monetrixa.BiometricMobile.Domain.Enums;

namespace Monetrixa.BiometricMobile.Infrastructure.Biometrics.Face;

public class TrustFaceBiometricProvider : IBiometricProvider
{
    public BiometricType Type => BiometricType.Face;

    public string ProviderName => "TrustFace Mock Provider";

    public Task<BiometricInitializationResult> InitializeAsync(
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new BiometricInitializationResult
        {
            IsSuccess = true,
            ProviderName = ProviderName,
            Message = "TrustFace SDK mock initialized successfully."
        });
    }

    public Task<BiometricCaptureResult> EnrollAsync(
        string customerId,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new BiometricCaptureResult
        {
            IsSuccess = true,
            Type = BiometricType.Face,
            ProviderName = ProviderName,
            TemplateData = [10, 20, 30, 40],
            Message = $"Face template enrolled for customer {customerId}."
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
            Type = BiometricType.Face,
            Status = VerificationStatus.Success,
            Score = 96.7,
            ProviderName = ProviderName,
            Message = $"Face verification successful for customer {customerId}."
        });
    }
}