using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class SectionGroupInfoModel
    {
        public string Title { get; set; }
        public IEnumerable<SectionInfoModel> Sections { get; set; } = [];
        
        public bool HasTitle() => !string.IsNullOrWhiteSpace(this.Title);
    }
}
