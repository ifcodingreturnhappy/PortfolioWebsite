using System.Collections.Generic;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase.Articles;

namespace PortfolioWebsite.BlazorUI.Models.WorkShowcase
{
    public class WorkShowcaseInfoModel
    {
        public IEnumerable<ArticleMetadataModel> ArticleMetadata { get; set; }
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}
