using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class ContentExcerptInfoModel
    {
        public string Title { get; set; }
        public TextDescriptionModel Description { get; set; }
        public TextIconModel Icon { get; set; }
        public IEnumerable<LinksInfoModel> Links { get; set; } = [];
        public string SecondaryTitle { get; set; }
        
        public bool HasSecondaryTitle() => !string.IsNullOrWhiteSpace(this.SecondaryTitle);
    }
}
