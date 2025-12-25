using PortfolioWebsite.BlazorUI.Models.Enums;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class MarginTypeMapper
    {
        public static string ToCss(this MarginType contentSpacing, Axis axis) => contentSpacing switch
        {
            MarginType.None => $"m{axis.ToCss()}-0",
            MarginType.Small => $"m{axis.ToCss()}-1",
            MarginType.Medium => $"m{axis.ToCss()}-3",
            MarginType.Large => $"m{axis.ToCss()}-5",
            MarginType.SmallOnLargerScreens => $"m{axis.ToCss()}-md-1",
            MarginType.MediumOnLargerScreens => $"m{axis.ToCss()}-md-3",
            MarginType.LargeOnLargerScreens => $"m{axis.ToCss()}-md-5",
            _ => $"m{axis.ToCss()}-0"
        };
    }
}
