using PortfolioWebsite.BlazorUI.Models.Enums;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class AxisMapper
    {
        public static string ToCss(this Axis axis)
        {
            return axis.ToString().ToLower();
        }
    }
}
