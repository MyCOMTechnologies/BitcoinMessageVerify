// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>
using BitcoinMessageVerify.ViewModels;

namespace BitcoinMessageVerify.Pages;

public partial class ResultsPage : ContentPage
{
	public ResultsPage(ResultsPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}