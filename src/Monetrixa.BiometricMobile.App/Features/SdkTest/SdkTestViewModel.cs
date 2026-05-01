using System.Collections.ObjectModel;
using System.Windows.Input;
using Monetrixa.BiometricMobile.App.ViewModels;
using Monetrixa.BiometricMobile.Application.Interfaces;
using Monetrixa.BiometricMobile.Domain.Enums;

namespace Monetrixa.BiometricMobile.App.Features.SdkTest;

public class SdkTestViewModel : BaseViewModel
{
    private readonly IBiometricOrchestrator _biometricOrchestrator;

    private string _statusMessage = "Prêt pour les tests biométriques.";

    public ObservableCollection<string> Results { get; } = new();

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public ICommand TestFaceEnrollmentCommand { get; }

    public ICommand TestFingerprintEnrollmentCommand { get; }

    public ICommand TestFullEnrollmentCommand { get; }

    public SdkTestViewModel(IBiometricOrchestrator biometricOrchestrator)
    {
        _biometricOrchestrator = biometricOrchestrator;

        Title = "SDK Test";

        TestFaceEnrollmentCommand = new Command(async () => await TestFaceEnrollmentAsync());
        TestFingerprintEnrollmentCommand = new Command(async () => await TestFingerprintEnrollmentAsync());
        TestFullEnrollmentCommand = new Command(async () => await TestFullEnrollmentAsync());
    }

    private async Task TestFaceEnrollmentAsync()
    {
        await RunEnrollmentTestAsync(
            "Test enrôlement Face ID",
            new[] { BiometricType.Face });
    }

    private async Task TestFingerprintEnrollmentAsync()
    {
        await RunEnrollmentTestAsync(
            "Test enrôlement Fingerprint",
            new[] { BiometricType.Fingerprint });
    }

    private async Task TestFullEnrollmentAsync()
    {
        await RunEnrollmentTestAsync(
            "Test enrôlement Face ID + Fingerprint",
            new[] { BiometricType.Face, BiometricType.Fingerprint });
    }

    private async Task RunEnrollmentTestAsync(
        string title,
        IReadOnlyList<BiometricType> requiredTypes)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            StatusMessage = $"{title} en cours...";
            Results.Clear();

            var customerId = $"CUSTOMER-{DateTime.Now:yyyyMMddHHmmss}";

            var results = await _biometricOrchestrator.EnrollAsync(
                customerId,
                requiredTypes);

            foreach (var result in results)
            {
                Results.Add(
                    $"{result.Type} | Success: {result.IsSuccess} | Provider: {result.ProviderName} | Message: {result.Message}");
            }

            StatusMessage = $"{title} terminé.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Erreur : {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}