using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class TextDescriptionModel
    {
        public HorizontalTextAlignment HorizontalTextAlignment { get; set; }
        public IEnumerable<string> Lines { get; set; } = [];
    }
}
