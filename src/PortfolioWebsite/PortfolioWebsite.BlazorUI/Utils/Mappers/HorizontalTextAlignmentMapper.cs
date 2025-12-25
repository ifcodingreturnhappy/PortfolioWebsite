using PortfolioWebsite.BlazorUI.Models.Enums;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class HorizontalTextAlignmentMapper
    {
        public static string ToCss(this HorizontalTextAlignment horizontalTextAlignment)
        {
            return horizontalTextAlignment switch
            {
                HorizontalTextAlignment.Left => "text-left",
                HorizontalTextAlignment.Center => "text-center",
                HorizontalTextAlignment.Right => "text-right",
                _ => "text-left",
            };
        }
    }
}
