using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class SectionGroupInfoModel
    {
        public ContentInfoModel Introduction { get; set; }
        public IEnumerable<SectionInfoModel> Sections { get; set; } = [];
    }
}
