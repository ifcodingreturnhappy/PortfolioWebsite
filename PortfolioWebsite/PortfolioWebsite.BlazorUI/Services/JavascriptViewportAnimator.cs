using Microsoft.AspNetCore.Hosting;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class JavascriptViewportAnimator : IJavascriptViewportAnimator
    {
        private readonly IWebHostEnvironment _env;
        readonly string animatableCssClassesFilePath = "/Data/OnViewportEnterCSSAnimations.json";

        public JavascriptViewportAnimator(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task SetupJavascriptViewportAnimation(IJSRuntime JSRuntime)
        {
            try
            {
                string json = File.ReadAllText($"{_env.WebRootPath}{animatableCssClassesFilePath}");

                await JSRuntime.InvokeVoidAsync("setupViewportAnimations", json);
            }
            catch (Exception)
            {
            }
        }
    }
}
