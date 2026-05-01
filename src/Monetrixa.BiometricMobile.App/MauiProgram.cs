using Microsoft.Extensions.Logging;
using Monetrixa.BiometricMobile.App.Features.SdkTest;
using Monetrixa.BiometricMobile.App.ViewModels;
using Monetrixa.BiometricMobile.Application.Interfaces;
using Monetrixa.BiometricMobile.Application.Services;
using Monetrixa.BiometricMobile.Infrastructure.Biometrics.Face;
using Monetrixa.BiometricMobile.Infrastructure.Biometrics.Fingerprint;

namespace Monetrixa.BiometricMobile.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<ViewModelLocator>();

        builder.Services.AddTransient<SdkTestViewModel>();
        builder.Services.AddTransient<SdkTestPage>();

        builder.Services.AddSingleton<IBiometricProvider, TrustFaceBiometricProvider>();
        builder.Services.AddSingleton<IBiometricProvider, TrustFingerprintBiometricProvider>();
        builder.Services.AddSingleton<IBiometricOrchestrator, BiometricOrchestrator>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
