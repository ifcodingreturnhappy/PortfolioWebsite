using PortfolioWebsite.BlazorUI.Models.Enums;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class ContentSourceCodeInfoModel
    {
        public string Language { get; set; }
        public string Code { get; set; }
        public string Caption { get; set; }
        public HorizontalTextAlignment HorizontalTextAlignment { get; set; }
    }
}
