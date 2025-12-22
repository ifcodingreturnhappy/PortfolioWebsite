using System.Collections.Generic;
using System.Linq;

namespace PortfolioWebsite.BlazorUI.Models.Theme
{
    public class ThemeInfoModel
    {
        public ColorInfoModel MainColor { get; set; }
        public ColorInfoModel SecondaryColor { get; set; }
        public ColorInfoModel HighlightedMainColor { get; set; }
        public ColorInfoModel HighlitedSecondaryColor { get; set; }

        private readonly Dictionary<string, ColorInfoModel> colors = [];

        public IReadOnlyDictionary<string, ColorInfoModel> GetColorByCssVarName()
        {
            if (this.colors.Any())
            {
                return this.colors;
            }

            if (this.MainColor is not null)
            {
                this.colors.Add(MainColor.CssVarName, this.MainColor);
            }
            if (this.SecondaryColor is not null)
            {
                this.colors.Add(SecondaryColor.CssVarName, this.SecondaryColor);
            }
            if (this.HighlightedMainColor is not null)
            {
                this.colors.Add(HighlightedMainColor.CssVarName, this.HighlightedMainColor);
            }
            if (this.HighlitedSecondaryColor is not null)
            {
                this.colors.Add(HighlitedSecondaryColor.CssVarName, this.HighlitedSecondaryColor);
            }

            return this.colors;
        }

        public void TryUpdateColor(string colorVarRef, string colorHex)
        {
            if (!this.GetColorByCssVarName().TryGetValue(colorVarRef, out var targetColor))
            {
                return;
            }

            targetColor.UpdateColor(colorHex);
        }
    }
}
