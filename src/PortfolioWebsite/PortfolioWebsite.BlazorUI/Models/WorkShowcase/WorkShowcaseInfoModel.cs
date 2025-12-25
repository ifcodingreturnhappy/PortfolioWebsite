using System.Collections.Generic;
using PortfolioWebsite.BlazorUI.Models.Common;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase.Articles;

namespace PortfolioWebsite.BlazorUI.Models.WorkShowcase
{
    public class WorkShowcaseInfoModel
    {
        public PageInfoModel Page { get; set; }
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}
