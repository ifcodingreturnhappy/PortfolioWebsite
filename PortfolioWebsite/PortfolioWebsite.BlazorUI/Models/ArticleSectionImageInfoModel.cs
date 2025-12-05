namespace PortfolioWebsite.BlazorUI.Models
{
    public class ArticleSectionImageInfoModel
    {
        public string Url { get; set; }
        public string AltText { get; set; }
        public string OverlayGifUrl { get; set; }
        public ArticleSectionImagePositioning Positioning { get; set; }

        public bool HasGifOverlay() => !string.IsNullOrWhiteSpace(this.OverlayGifUrl);
    }
}
