// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using CommunityToolkit.Mvvm.Input;
using BitcoinMessageVerify.Services.Bitcoin;
using BitcoinMessageVerify.ViewModels;
using BitcoinMessageVerify.Resources.Strings;
using BitcoinMessageVerify.Services.CoinGecko;
using BitcoinMessageVerify.Services.Memspace;


namespace BitcoinMessageVerify.Pages;

/// <summary>
/// This is the controller for the page
/// </summary>
public partial class MainPage : ContentPage
{
	private readonly ICoinGeckoService _coinGeckoService;
	private readonly IMemspaceService _memspaceService;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="coinGeckoService"></param>
	public MainPage(ICoinGeckoService coinGeckoService, IMemspaceService memspaceService)
	{
		_coinGeckoService = coinGeckoService;
		_memspaceService = memspaceService;

		InitializeComponent();
		BindingContext = new MainPageViewModel();

		this.VerifyMsg.Command = new AsyncRelayCommand(OnVerifyMessageAsync);
	}


	/// <summary>
	/// Event Handler for OnSignWifMessage Button
	/// </summary>
	/// <exception cref="ArgumentException"></exception>
	private async Task OnVerifyMessageAsync()
	{
		if (BindingContext is MainPageViewModel viewModel)
		{
			try
			{
				viewModel.ErrorMessage = "";

				if (string.IsNullOrEmpty(viewModel.BitcoinAddress)) throw new ArgumentException(AppResources.BitcoinAddressIsRequired);
				if (string.IsNullOrEmpty(viewModel.Message)) throw new ArgumentException(AppResources.MessageIsRequired);
				if (string.IsNullOrEmpty(viewModel.SignedMessage)) throw new ArgumentException(AppResources.MessageIsRequired);

				if (!BitcoinServices.IsValidBitcoinAddress(viewModel.BitcoinAddress)) throw new ArgumentException(AppResources.BitcoinAddressIsInvalid);

				// Verify the message here
				var verified = BitcoinServices.VerifyMessage(viewModel.BitcoinAddress, viewModel.Message, viewModel.SignedMessage);

				if (verified)
					await ShowValidMsgResults(viewModel.BitcoinAddress);
				else
					throw new Exception(AppResources.ValidationFailed);

			}
			catch (Exception ex)
			{
				viewModel.ErrorMessage = ex.Message;
			}
		}
	}

	private async Task ShowValidMsgResults(string bitcoinAddress)
	{
		IsBusy = true;

		var resultsPageViewModel = new ResultsPageViewModel();
		var currentPrice = await _coinGeckoService.GetCurrentPriceAsync();
		var txos = await _memspaceService.GetAddressTransactionsAsync(bitcoinAddress);
		var dataPoints = _memspaceService.CalculateBalance(txos, bitcoinAddress);

		resultsPageViewModel.CoinCurrentPrice = currentPrice;
		resultsPageViewModel.CoinAddress = bitcoinAddress;
		resultsPageViewModel.CoinName = "Bitcoin";
		resultsPageViewModel.CoinSymbol = "BTC";
		resultsPageViewModel.TxData = dataPoints;

		resultsPageViewModel.Quantity = 0.00000000m;
		resultsPageViewModel.Amount = 0.00m;
		
		IsBusy = false;
		
		await Navigation.PushAsync(new ResultsPage(resultsPageViewModel));
	}

}

