namespace PortfolioWebsite.BlazorUI.Models.Common
{
    // TODO: Rename this to section row to match component?
    public class SectionInfoModel
    {
        public ContentInfoModel MainContent { get; set; }
        public ContentInfoModel ExtraContent { get; set; }
        public ContentPositioning ContentPositioning { get; set; }
        public ContentSpacing ContentSpacing { get; set; }
    }
}
