using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class WorkArticleMetadataModel
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string PageRef { get; set; }
        public DateTime PublishDate { get; set; }
        public List<string> Tags { get; set; }
    }
}
