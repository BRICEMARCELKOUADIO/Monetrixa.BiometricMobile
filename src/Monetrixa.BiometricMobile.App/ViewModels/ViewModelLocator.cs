using Microsoft.Extensions.DependencyInjection;
using Monetrixa.BiometricMobile.App.Features.SdkTest;

namespace Monetrixa.BiometricMobile.App.ViewModels;

public class ViewModelLocator
{
    private readonly IServiceProvider _serviceProvider;

    public ViewModelLocator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public SdkTestViewModel SdkTestViewModel =>
        _serviceProvider.GetRequiredService<SdkTestViewModel>();
}