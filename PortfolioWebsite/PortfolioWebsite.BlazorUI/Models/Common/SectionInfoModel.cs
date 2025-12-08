namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class SectionInfoModel
    {
        public ContentInfoModel MainContent { get; set; }
        public ContentInfoModel ExtraContent { get; set; }
        public bool ShouldShowMainContentFirst { get; set; }
        public ContentPositioning ContentPositioning { get; set; }
    }
}
