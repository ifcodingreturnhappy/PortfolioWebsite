using System.Collections;
using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class WhoAmIInfoModel
    {
        public string Title { get; set; }
        public TextDescriptionModel Description { get; set; }
        public string SecondaryTitle { get; set; }
        public IEnumerable<WhoAmISectionInfoModel> Sections { get; set; } // TODO: see if we can generalize a section
    }
}
