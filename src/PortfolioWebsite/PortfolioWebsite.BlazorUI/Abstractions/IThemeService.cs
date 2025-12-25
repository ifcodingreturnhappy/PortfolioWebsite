using System.Threading.Tasks;
using PortfolioWebsite.BlazorUI.Models.Theme;

namespace PortfolioWebsite.BlazorUI.Abstractions
{
    public interface IThemeService
    {
        public Task InitializeAsync();
        public Task<ThemeInfoModel> GetThemeAsync();
        public Task UpdateColorAsync(string colorVarRef, string colorHex);
        public Task ResetThemeAsync();
    }
}
