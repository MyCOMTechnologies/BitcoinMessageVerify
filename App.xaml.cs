// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using BitcoinMessageVerify.Pages;
using BitcoinMessageVerify.Services.CoinGecko;
using BitcoinMessageVerify.Services.CryptoCompare;

namespace BitcoinMessageVerify;

public partial class App : Application
{
	private readonly IServiceProvider _serviceProvider;

	public App(IServiceProvider serviceProvider)
	{
		this._serviceProvider = serviceProvider;

		this.UserAppTheme = AppTheme.Light;

		InitializeComponent();
	
		// DependencyService.Register<ICoinDataService, CoinDataService>();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		 // Resolve MainPage
        var mainPage = _serviceProvider.GetRequiredService<MainPage>();

		var window = new Window
		{
			Page = new NavigationPage(mainPage)
		};

		return window;
	}
}
