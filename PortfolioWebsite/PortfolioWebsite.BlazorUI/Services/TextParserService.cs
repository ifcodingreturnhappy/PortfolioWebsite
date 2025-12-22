using Microsoft.AspNetCore.Components;
using PortfolioWebsite.BlazorUI.Abstractions;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class TextParserService : ITextParserService
    {
        private readonly ReplaceableMarkers[] replaceableMarkers = [
            new()
            {
                StartTag = "<*",
                EndTag = "*>",
                HtmlStartTag = "<span class=\"highlighted-main-color\">",
                HtmlEndTag = "</span>"
            },
            // TODO: make this a link instead
            new()
            {
                StartTag = "<*",
                EndTag = "*>",
                HtmlStartTag = "<span class=\"underlined-text\">",
                HtmlEndTag = "</span>"
            },
        ];

        private class ReplaceableMarkers
        {
            public string StartTag { get; set; }
            public string EndTag { get; set; }
            public string HtmlStartTag { get; set; }
            public string HtmlEndTag { get; set; }
        }

        public MarkupString Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new MarkupString(string.Empty);
            }

            var parsedText = text;

            foreach (var marker in replaceableMarkers)
            {
                parsedText = parsedText.Replace(marker.StartTag, marker.HtmlStartTag)
                                       .Replace(marker.EndTag, marker.HtmlEndTag);
            }

            return (MarkupString)parsedText;
        }
    }
}
