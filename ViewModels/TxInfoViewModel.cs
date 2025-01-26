// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>

using Telerik.Maui.Controls;
using Telerik.Maui.Controls.Compatibility.Chart;

using BitcoinMessageVerify.Services.Memspace;


namespace BitcoinMessageVerify.ViewModels;

public class TxInfoViewModel : NotifyPropertyChangedBase
{
    private decimal? coinCurrentPrice;
    private string? coinAddress;
    private string? coinName;
    private string? coinSymbol;
    private TimeInterval chartMajorStepUnit;
    private double chartMajorStep;
    private string? chartLabelFormat;
    private string? dataGridLabelFormat;
    private IList<Tx>? txData;
    private bool isChartLoading;
    
    public TxInfoViewModel()
    {
        this.CoinName = "Bitcoin";
        this.CoinSymbol = "BTC";
        this.ChartMajorStep = 1.0;
        this.TxData = [];
        this.IsChartLoading = false;
    }

    public IList<Tx>? TxData
    {
        get => this.txData;
        set => this.UpdateValue(ref this.txData, value);
    }

    public bool IsChartLoading
    {
        get => this.isChartLoading;
        private set => this.UpdateValue(ref this.isChartLoading, value);
    }

    public decimal? CoinCurrentPrice
    {
        get => this.coinCurrentPrice;
        set 
        {
            if (value == null)
                this.UpdateValue(ref this.coinCurrentPrice, value);
            else
                this.UpdateValue(ref this.coinCurrentPrice, Math.Round(value.Value, 2));
        }
    }

    public string? CoinAddress
    {
        get => this.coinAddress;
        set => this.UpdateValue(ref this.coinAddress, value);
    }

    public string? CoinSymbol
    {
        get => this.coinSymbol;
        set => this.UpdateValue(ref this.coinSymbol, value);
    }

    public string? CoinName
    {
        get => this.coinName;
        set => this.UpdateValue(ref this.coinName, value);
    }

    public TimeInterval ChartMajorStepUnit
    {
        get => this.chartMajorStepUnit;
        private set => this.UpdateValue(ref this.chartMajorStepUnit, value);
    }

    public double ChartMajorStep
    {
        get => this.chartMajorStep;
        private set => this.UpdateValue(ref this.chartMajorStep, value);
    }

    public string ChartLabelFormat
    {
        get => this.chartLabelFormat;
        private set => this.UpdateValue(ref this.chartLabelFormat, value);
    }

    public string DataGridLabelFormat
    {
        get => this.dataGridLabelFormat;
        private set => this.UpdateValue(ref this.dataGridLabelFormat, value);
    }

    public void InitializeTxData(string coinAddress, string coinSymbol, string coinName, decimal coinCurrentPrice)
    {
        this.CoinAddress = coinAddress;
        this.CoinName = coinName;
        this.CoinSymbol = coinSymbol;
        this.CoinCurrentPrice = coinCurrentPrice;

        this.DownLoadTxData();
    }

    private async void DownLoadTxData()
    {
        if (string.IsNullOrEmpty(this.CoinAddress) == false)
        {
            this.IsChartLoading = true;
            var coinService = DependencyService.Get<IMemspaceService>();
            this.TxData = await coinService.GetAddressTransactionsAsync(this.CoinAddress);
            this.IsChartLoading = false;
        }
    }

}
