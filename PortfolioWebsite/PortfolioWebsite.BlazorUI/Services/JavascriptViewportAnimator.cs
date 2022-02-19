using Microsoft.JSInterop;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace PortfolioWebsite.BlazorUI.Services
{
    public class JavascriptViewportAnimator : IJavascriptViewportAnimator
    {
        readonly string animatableCssClassesFilePath = "/Data/OnViewportEnterCSSAnimations.json";

        private readonly HttpClient _client;

        public JavascriptViewportAnimator(HttpClient client)
        {
            _client = client;
        }

        public async Task SetupJavascriptViewportAnimation(IJSRuntime JSRuntime)
        {
            try
            {
                //string json = File.ReadAllText($"{_env.WebRootPath}{animatableCssClassesFilePath}");
                var json = await _client.GetStringAsync(animatableCssClassesFilePath);

                await JSRuntime.InvokeVoidAsync("setupViewportAnimations", json);
            }
            catch (Exception)
            {
            }
        }
    }
}
