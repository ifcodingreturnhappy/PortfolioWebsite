using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class SectionGroupInfoModel
    {
        public IEnumerable<SectionInfoModel> Sections { get; set; } = [];
    }
}
