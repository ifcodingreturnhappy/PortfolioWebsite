using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using PortfolioWebsite.BlazorUI.Abstractions;
using PortfolioWebsite.BlazorUI.Services;
using PortfolioWebsite.BlazorUI.Utils.Serializers.Json;

namespace PortfolioWebsite.BlazorUI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services, string baseAddress)
        {
            return services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJsonSerializer, JsonSerializer>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IJsRuntimeService, JsRuntimeService>()
                           .AddScoped<IPortfolioDataService, PortfolioDataService>()
                           .AddScoped<IThemeService, ThemeService>() 
                           .AddScoped<ITextParserService, TextParserService>();
        }
    }
}
