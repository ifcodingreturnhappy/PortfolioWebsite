using System.Threading.Tasks;
using PortfolioWebsite.BlazorUI.Abstractions;
using PortfolioWebsite.BlazorUI.Models.Theme;
using PortfolioWebsite.BlazorUI.Utils.Converters;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IJsRuntimeService jsRuntimeService;
        private readonly IPortfolioDataService portfolioDataService;

        private const string cssVariableNameMainColor = "--main-color";
        private const string cssVariableNameSecondaryColor = "--secondary-color";
        private const string cssVariableNameHighlightedMainColor = "--highlighted-main-color";
        private const string cssVariableNameHighlightedSecondaryColor = "--highlighted-secondary-color";
        private const string localStorageThemeKey = "theme";

        private ThemeInfoModel theme;

        public ThemeService(IJsRuntimeService jsRuntimeService, IPortfolioDataService portfolioDataService)
        {
            this.jsRuntimeService = jsRuntimeService;
            this.portfolioDataService = portfolioDataService;
        }

        public async Task InitializeAsync()
        {
            this.theme = await this.GetThemeFromStorageAsync();

            if (this.theme is null)
            {
                return;
            }

            foreach (var color in this.theme.GetColorByCssVarName().Values)
            {
                await this.UpdateColorInCssAsync(color.CssVarName, color.Hex);
            }
        }

        public async Task<ThemeInfoModel> GetThemeAsync()
        {
            if (this.theme is not null)
            {
                return this.theme;
            }

            this.theme = await this.GetThemeFromStorageAsync();

            if (this.theme is not null)
            {
                return this.theme;
            }

            this.theme = await this.GetInitialThemeFromCssAsync();

            await this.SaveThemeToStorageAsync();

            return this.theme;
        }

        public async Task UpdateColorAsync(string colorVarRef, string colorHex)
        {
            await this.UpdateColorInCssAsync(colorVarRef, colorHex);
            await this.SaveThemeToStorageAsync();
        }

        public async Task ResetThemeAsync()
        {
            foreach (var color in this.theme.GetColorByCssVarName().Values)
            {
                await this.UpdateColorInCssAsync(color.CssVarName, color.DefaultHex);
            }
            await this.SaveThemeToStorageAsync();
        }

        private async Task<ThemeInfoModel> GetInitialThemeFromCssAsync()
        {
            var settings = await this.portfolioDataService.GetSettingsAsync();

            var mainColor = await this.GetColorInfoModelAsync(cssVariableNameMainColor, settings.MainColorDisplayName);
            var secondaryColor = await this.GetColorInfoModelAsync(cssVariableNameSecondaryColor, settings.SecondaryColorDisplayName);
            var highlightedMainColor = await this.GetColorInfoModelAsync(cssVariableNameHighlightedMainColor, settings.HighlightedMainColorDisplayName);
            var highlightedSecondaryColor = await this.GetColorInfoModelAsync(cssVariableNameHighlightedSecondaryColor, settings.HighlightedSecondaryColorDisplayName);

            var theme = new ThemeInfoModel
            {
                MainColor = mainColor,
                SecondaryColor = secondaryColor,
                HighlightedMainColor = highlightedMainColor,
                HighlitedSecondaryColor = highlightedSecondaryColor,
            };

            return theme;
        }

        private async Task<ColorInfoModel> GetColorInfoModelAsync(string cssVariableNameOfColor, string colorDisplayName)
        {
            var colorRgb = await this.jsRuntimeService.GetCssVariable(cssVariableNameOfColor);
            var colorHex = ColorConverter.RgbToHex(colorRgb);

            var color = new ColorInfoModel
            {
                DisplayName = colorDisplayName,
                CssVarName = cssVariableNameOfColor,
                Hex = colorHex,
                DefaultHex = colorHex,
            };
            return color;
        }

        private Task UpdateColorInCssAsync(string colorVarRef, string colorHex)
        {
            this.theme.TryUpdateColor(colorVarRef, colorHex);
            return this.jsRuntimeService.SetCssColorAsync(colorVarRef, colorHex);
        }

        private Task SaveThemeToStorageAsync()
        {
            return this.jsRuntimeService.SaveToLocalStorageAsync(localStorageThemeKey, this.theme);
        }

        private Task<ThemeInfoModel> GetThemeFromStorageAsync()
        {
            return this.jsRuntimeService.ReadFromLocalStorageAsync<ThemeInfoModel>(localStorageThemeKey);
        }
    }
}
