using Monetrixa.BiometricMobile.Application.Interfaces;
using Monetrixa.BiometricMobile.Application.Results;
using Monetrixa.BiometricMobile.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monetrixa.BiometricMobile.Application.Services
{
    public class BiometricOrchestrator : IBiometricOrchestrator
    {
        private readonly IEnumerable<IBiometricProvider> _providers;

        public BiometricOrchestrator(IEnumerable<IBiometricProvider> providers)
        {
            _providers = providers;
        }

        public async Task<IReadOnlyList<BiometricCaptureResult>> EnrollAsync(
            string customerId,
            IReadOnlyList<BiometricType> requiredTypes,
            CancellationToken cancellationToken = default)
        {
            var results = new List<BiometricCaptureResult>();

            foreach (var requiredType in requiredTypes)
            {
                var provider = GetProvider(requiredType);

                var initializationResult = await provider.InitializeAsync(cancellationToken);

                if (!initializationResult.IsSuccess)
                {
                    results.Add(new BiometricCaptureResult
                    {
                        IsSuccess = false,
                        Type = requiredType,
                        ProviderName = provider.ProviderName,
                        Message = initializationResult.Message,
                        RawResponse = initializationResult.RawResponse
                    });

                    continue;
                }

                var captureResult = await provider.EnrollAsync(customerId, cancellationToken);
                results.Add(captureResult);
            }

            return results;
        }

        public async Task<IReadOnlyList<BiometricVerificationResult>> VerifyAsync(
            string customerId,
            BiometricDecisionMode decisionMode,
            IReadOnlyDictionary<BiometricType, byte[]> referenceTemplates,
            CancellationToken cancellationToken = default)
        {
            var requiredTypes = GetRequiredTypes(decisionMode);
            var results = new List<BiometricVerificationResult>();

            foreach (var requiredType in requiredTypes)
            {
                if (!referenceTemplates.TryGetValue(requiredType, out var referenceTemplate))
                {
                    results.Add(new BiometricVerificationResult
                    {
                        IsSuccess = false,
                        Type = requiredType,
                        Status = VerificationStatus.Failed,
                        Message = $"Aucun template disponible pour {requiredType}."
                    });

                    continue;
                }

                var provider = GetProvider(requiredType);

                var initializationResult = await provider.InitializeAsync(cancellationToken);

                if (!initializationResult.IsSuccess)
                {
                    results.Add(new BiometricVerificationResult
                    {
                        IsSuccess = false,
                        Type = requiredType,
                        Status = VerificationStatus.Error,
                        ProviderName = provider.ProviderName,
                        Message = initializationResult.Message,
                        RawResponse = initializationResult.RawResponse
                    });

                    continue;
                }

                var verificationResult = await provider.VerifyAsync(
                    customerId,
                    referenceTemplate,
                    cancellationToken);

                results.Add(verificationResult);
            }

            return results;
        }

        private IBiometricProvider GetProvider(BiometricType biometricType)
        {
            var provider = _providers.FirstOrDefault(x => x.Type == biometricType);

            if (provider is null)
            {
                throw new InvalidOperationException(
                    $"Aucun provider biométrique n'est enregistré pour le type {biometricType}.");
            }

            return provider;
        }

        private static IReadOnlyList<BiometricType> GetRequiredTypes(BiometricDecisionMode decisionMode)
        {
            return decisionMode switch
            {
                BiometricDecisionMode.FaceOnly => new[] { BiometricType.Face },
                BiometricDecisionMode.FingerprintOnly => new[] { BiometricType.Fingerprint },
                BiometricDecisionMode.FaceAndFingerprint => new[] { BiometricType.Face, BiometricType.Fingerprint },
                BiometricDecisionMode.FaceOrFingerprint => new[] { BiometricType.Face, BiometricType.Fingerprint },
                _ => throw new ArgumentOutOfRangeException(nameof(decisionMode), decisionMode, null)
            };
        }
    }
}
