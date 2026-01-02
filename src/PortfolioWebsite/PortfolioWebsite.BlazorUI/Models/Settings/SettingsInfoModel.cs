namespace PortfolioWebsite.BlazorUI.Models.Settings
{
    public class SettingsInfoModel
    {
        public int DataFetchSimulatedDelayInMs { get; set; }
        public string MainColorDisplayName { get; set; }
        public string SecondaryColorDisplayName { get; set; }
        public string HighlightedMainColorDisplayName { get; set; }
        public string HighlightedSecondaryColorDisplayName { get; set; }


        public bool ShouldSmiluateDelayLoadingData() => this.DataFetchSimulatedDelayInMs > 0;
    }
}
