using Microsoft.AspNetCore.Components;
using PortfolioWebsite.BlazorUI.Abstractions;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class TextParserService : ITextParserService
    {
        private readonly ReplaceableMarkers[] replaceableMarkers = [
            // Example:
            // <* My Highlighted Text *>
            new ()
            {
                StartTag = "<*",
                EndTag = "*>",
                HtmlStartTag = "<span class=\"highlighted-main-color\">",
                HtmlEndTag = "</span>"
            },
            // Example:
            // "<ref href=\"https://www.example.com/\">My Link Label ref>"
            new()
            {
                StartTag = "<ref",
                EndTag = "ref>",
                HtmlStartTag = "<a class=\"underlined-text\" target=\"_blank\" rel=\"noopener noreferrer\" ",
                HtmlEndTag = "</a>"
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
