namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class ContentImageInfoModel
    {
        public string Url { get; set; }
        public string AltText { get; set; }
        public string OverlayGifUrl { get; set; }
        public string OverlayGifWidth { get; set; }

        public bool HasGifOverlay() => !string.IsNullOrWhiteSpace(OverlayGifUrl);
    }
}
