using Microsoft.AspNetCore.Components;

namespace PortfolioWebsite.BlazorUI.Abstractions
{
    public interface ITextParserService
    {
        public MarkupString Parse(string text);
    }
}
