// <copyright company="Chris McGorty" author="Chris McGorty">
//     Copyright (c) 2024 All Rights Reserved
// </copyright>

namespace BitcoinMessageVerify.Views
{
    public partial class TxInfoChartView : ContentView
    {
        public TxInfoChartView()
        {
            this.InitializeComponent();
        }

        private void OnChartPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
#if __IOS__ || MACCATALYST
            // TODO: Remove this workaround after the following issue is fixed: https://github.com/dotnet/maui/issues/4849
            if (e.PropertyName == nameof(View.IsVisible))
            {
                var handler = ((Telerik.Maui.Controls.Compatibility.Chart.RadCartesianChart)sender).Handler as global::UIKit.UIView;
                handler?.Superview.SetNeedsLayout();
            }
#endif
        }

    }
}