using Monetrixa.BiometricMobile.Application.Interfaces;
using Monetrixa.BiometricMobile.Application.Results;
using Monetrixa.BiometricMobile.Application.Services;
using Monetrixa.BiometricMobile.Domain.Enums;

namespace Monetrixa.BiometricMobile.Tests.Application;

public class BiometricOrchestratorTests
{
    [Fact]
    public async Task EnrollAsync_WithFaceProvider_ShouldReturnFaceCaptureResult()
    {
        // Arrange
        var providers = new List<IBiometricProvider>
        {
            new FakeFaceBiometricProvider()
        };

        var orchestrator = new BiometricOrchestrator(providers);

        // Act
        var results = await orchestrator.EnrollAsync(
            customerId: "CUSTOMER-001",
            requiredTypes: new[] { BiometricType.Face });

        // Assert
        Assert.Single(results);
        Assert.True(results[0].IsSuccess);
        Assert.Equal(BiometricType.Face, results[0].Type);
    }

    private sealed class FakeFaceBiometricProvider : IBiometricProvider
    {
        public BiometricType Type => BiometricType.Face;

        public string ProviderName => "FakeFaceProvider";

        public Task<BiometricInitializationResult> InitializeAsync(
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new BiometricInitializationResult
            {
                IsSuccess = true,
                ProviderName = ProviderName,
                Message = "Fake Face SDK initialized"
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
                TemplateData = [1, 2, 3],
                Message = $"Face enrolled for {customerId}"
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
                ProviderName = ProviderName,
                Score = 98.5,
                Message = $"Face verified for {customerId}"
            });
        }
    }
}