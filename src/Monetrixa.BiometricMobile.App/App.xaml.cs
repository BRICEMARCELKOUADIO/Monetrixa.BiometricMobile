using Microsoft.Extensions.DependencyInjection;
using Monetrixa.BiometricMobile.App.ViewModels;

namespace Monetrixa.BiometricMobile.App;

public partial class App : Microsoft.Maui.Controls.Application
{
	public App(ViewModelLocator viewModelLocator)
	{
		InitializeComponent();

        Resources.Add(nameof(ViewModelLocator), viewModelLocator);
    }

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}