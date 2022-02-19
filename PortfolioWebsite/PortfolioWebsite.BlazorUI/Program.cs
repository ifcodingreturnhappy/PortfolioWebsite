using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PortfolioWebsite.BlazorUI.Models;
using PortfolioWebsite.BlazorUI.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<INavigationController, NavigationController>();
            builder.Services.AddSingleton<IJavascriptViewportAnimator, JavascriptViewportAnimator>();
            builder.Services.AddSingleton<IPageEnumerator<WorkArticleMetadataModel>, WorkArticleMetadataEnumerator>();
            builder.Services.AddSingleton<HttpClient>();

            //services.AddSingleton<IConfiguration>(provider => new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .AddJsonFile("info.json", true)
            //    .Build()
            //);

            await builder.Build().RunAsync();
        }
    }
}
