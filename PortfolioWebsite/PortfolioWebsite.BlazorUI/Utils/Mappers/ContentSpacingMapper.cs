using PortfolioWebsite.BlazorUI.Models.Enums;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class ContentSpacingMapper
    {
        public static string ToCss(this ContentSpacing contentSpacing) => contentSpacing switch
        {
            ContentSpacing.None => "m-0",
            ContentSpacing.Small => "m-2",
            ContentSpacing.Medium => "m-4",
            ContentSpacing.Large => "m-5",
            _ => "m-1"
        };
    }
}
