using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class PageInfoModel
    {
        public ContentExcerptInfoModel Introduction { get; set; }
        public IEnumerable<SectionInfoModel> Sections { get; set; } = [];
    }
}
