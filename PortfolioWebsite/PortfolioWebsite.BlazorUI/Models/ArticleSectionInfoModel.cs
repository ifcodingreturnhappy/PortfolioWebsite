using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class ArticleSectionInfoModel
    {
        public string Title { get; set; }
        public TextDescriptionModel Description { get; set; }
        public ArticleSectionImageInfoModel Image { get; set; }
        public IEnumerable<ArticleSectionLinksInfoModel> Links { get; set; } = [];
    }
}
