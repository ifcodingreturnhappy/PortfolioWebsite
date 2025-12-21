namespace PortfolioWebsite.BlazorUI.Models.Settings
{
    public class SettingsInfoModel
    {
        public int DataFetchSimulatedDelayInMs { get; set; }

        public bool ShouldSmiluateDelayLoadingData() => this.DataFetchSimulatedDelayInMs > 0;
    }
}
