using System;
using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public TextDescriptionModel Description { get; set; }
        public IEnumerable<ArticleSectionInfoModel> Sections { get; set; } = [];
    }
}
