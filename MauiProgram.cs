// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using Telerik.Maui.Controls.Compatibility;
using BitcoinMessageVerify.Services.CoinGecko;
using BitcoinMessageVerify.Services.Memspace;
using BitcoinMessageVerify.Pages;
using BitcoinMessageVerify.ViewModels;
using BitcoinMessageVerify.Views;


[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace BitcoinMessageVerify;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseTelerik()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesome");
				fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesome");
				fonts.AddFont("Consola.ttf", "Consola");
			});

		// Add HttpClientFactory
    	builder.Services.AddHttpClient();

    	// Register your service that uses HttpClient
    	builder.Services.AddSingleton<IMemspaceService, MemspaceService>();
		builder.Services.AddSingleton<ICoinGeckoService, CoinGeckoService>();

		builder.Services.AddTransient<MainPage>();

		// Register Views
		builder.Services.AddTransient<TxInfoView>();

		return builder.Build();
	}
}
