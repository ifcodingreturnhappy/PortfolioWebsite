using PortfolioWebsite.BlazorUI.Models.Enums;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class SectionInfoModel
    {
        public ContentInfoModel MainContent { get; set; }
        public ContentInfoModel ExtraContent { get; set; }
        public ContentPositioning ContentPositioning { get; set; }
        public MarginInfoModel Margin { get; set; }
    }
}
