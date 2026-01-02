using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PortfolioWebsite.BlazorUI.Abstractions;

namespace PortfolioWebsite.BlazorUI.Extensions
{
    public static class WebAssemblyHostExtensions
    {
        public static async Task InitializeAsync(this WebAssemblyHost host)
        {
            var themeService = host.Services.GetService<IThemeService>();
            await themeService.InitializeAsync();

            var jsRuntimeService = host.Services.GetService<IJsRuntimeService>();
            await jsRuntimeService.ShowAppAsync();
        }
    }
}
