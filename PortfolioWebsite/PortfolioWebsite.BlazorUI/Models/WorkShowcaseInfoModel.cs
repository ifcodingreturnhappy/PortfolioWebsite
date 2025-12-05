using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class WorkShowcaseInfoModel
    {
        public IEnumerable<ArticleMetadataModel> ArticleMetadata { get; set; }
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}
