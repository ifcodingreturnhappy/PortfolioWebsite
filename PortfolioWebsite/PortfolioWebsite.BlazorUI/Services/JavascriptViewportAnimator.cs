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
        readonly string animatableCssClassesFilePath = "wwwroot/Data/OnViewportEnterCSSAnimations.json";

        public async Task SetupJavascriptViewportAnimation(IJSRuntime JSRuntime)
        {
            string json = File.ReadAllText(animatableCssClassesFilePath);

            await JSRuntime.InvokeVoidAsync("setupViewportAnimations", json);
        }
    }
}
