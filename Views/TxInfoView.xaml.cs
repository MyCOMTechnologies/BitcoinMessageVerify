// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using BitcoinMessageVerify.Services.Memspace;
using BitcoinMessageVerify.ViewModels;

namespace BitcoinMessageVerify.Views;

/// <summary>
/// Controller for the view component
/// </summary>
public partial class TxInfoView : ContentView
{
	private TxInfoViewModel _txInfoViewModel;

	public TxInfoView()
	{
		InitializeComponent();

		_txInfoViewModel = new TxInfoViewModel();
				
		BindingContext = _txInfoViewModel;
	}

	public void SetCurrentPrice(decimal? currentPrice) => _txInfoViewModel.CoinCurrentPrice =  currentPrice;
	public void SetCoinName(string name) => _txInfoViewModel.CoinName = name;
	public void SetCoinSymbol(string symbol) => _txInfoViewModel.CoinSymbol = symbol;
	public void SetCoinAddress(string address) => _txInfoViewModel.CoinAddress = address;
	public void SetTxData(List<Tx>? data) => _txInfoViewModel.TxData = data;

}