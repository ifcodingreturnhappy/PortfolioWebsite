using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Services
{
    interface IJavascriptViewportAnimator
    {
        Task SetupJavascriptViewportAnimation(IJSRuntime JSRuntime);
    }
}
