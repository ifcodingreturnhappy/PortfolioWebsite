using PortfolioWebsite.BlazorUI.Models.Enums;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class ContentPositioningMapper
    {
        public static (string, string) ToCss(this ContentPositioning contentPositioning)
        {
            if (contentPositioning == ContentPositioning.MainContentOnly)
            {
                return ("col-md-12 d-flex justify-content-center", "col-md-12 d-flex justify-content-center");
            }

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
            
            var mainOrderClasses = $"col-md-6 d-flex justify-content-center order-{mainOrderSmall} order-md-{mainOrderLarge}";
            var extraOrderClasses = $"col-md-6 d-flex justify-content-center order-{extraOrderSmall} order-md-{extraOrderLarge}";

            return (mainOrderClasses, extraOrderClasses);
        }
    }
}
