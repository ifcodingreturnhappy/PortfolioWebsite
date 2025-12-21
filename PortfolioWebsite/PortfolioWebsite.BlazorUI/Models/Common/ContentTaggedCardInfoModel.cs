using System;
using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Common
{
    public class ContentTaggedCardInfoModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
