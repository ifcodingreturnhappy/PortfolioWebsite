using PortfolioWebsite.BlazorUI.Models.Common;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class ContentPositioningMapper
    {
        public static (string, string) ToCss(this ContentPositioning contentPositioning)
        {
            var mainOrderSmall = 1;
            var mainOrderLarge = 1;
            var extraOrderSmall = 2;
            var extraOrderLarge = 2;

            switch (contentPositioning)
            {
                case ContentPositioning.ExtraContentFirst:
                    mainOrderSmall = 2;
                    extraOrderSmall = 1;
                    mainOrderLarge = 2;
                    extraOrderLarge = 1;
                    break;

                case ContentPositioning.ExtraContentFirstOnLargeScreens:
                    mainOrderSmall = 1;
                    extraOrderSmall = 2;
                    mainOrderLarge = 2;
                    extraOrderLarge = 1;
                    break;
            }
            
            var mainOrderClasses = $"order-{mainOrderSmall} order-md-{mainOrderLarge}";
            var extraOrderClasses = $"order-{extraOrderSmall} order-md-{extraOrderLarge}";

            return (mainOrderClasses, extraOrderClasses);
        }
    }
}
