using Microsoft.AspNetCore.Components;
using PortfolioWebsite.BlazorUI.Abstractions;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class TextParserService : ITextParserService
    {
        // TODO: improve
        public MarkupString Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new MarkupString(string.Empty);
            }

            var parsedText = text.Replace("<*", "<span class=\"stand-out-text\">")
                                 .Replace("*>", "</span>")
                                 .Replace("<w", "<span class=\"white-text\">")
                                 .Replace("w>", "</span>");

            return (MarkupString)parsedText;
        }
    }
}
