using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortfolioWebsite.BlazorUI.Extensions;

namespace PortfolioWebsite.BlazorUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient(builder.HostEnvironment.BaseAddress)
                            .AddUtils()
                            .AddStores()
                            .AddServices();

            await builder.Build().RunAsync();
        }
    }
}
