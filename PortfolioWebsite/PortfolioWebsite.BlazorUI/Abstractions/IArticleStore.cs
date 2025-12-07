using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortfolioWebsite.BlazorUI.Models.ContactMe;
using PortfolioWebsite.BlazorUI.Models.WhoAmI;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase.Articles;

namespace PortfolioWebsite.BlazorUI.Abstractions
{
    public interface IArticleStore
    {
        public Task<WhoAmIInfoModel> GetWhoAmIAsync();
        public Task<IEnumerable<ArticleMetadataModel>> GetArticleMetadataAsync();
        public Task<IEnumerable<ArticleTagModel>> GetAvailableTagsAsync();
        public Task<ArticleModel> GetArticleByIdAsync(Guid articleId);
        public Task<ContactMeInfoModel> GetContactMeInfoAsync();
    }
}
