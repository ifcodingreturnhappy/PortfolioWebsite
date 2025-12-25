using System;
using System.Threading.Tasks;
using PortfolioWebsite.BlazorUI.Models.ContactMe;
using PortfolioWebsite.BlazorUI.Models.Home;
using PortfolioWebsite.BlazorUI.Models.Navigation;
using PortfolioWebsite.BlazorUI.Models.Settings;
using PortfolioWebsite.BlazorUI.Models.WhoAmI;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase.Articles;

namespace PortfolioWebsite.BlazorUI.Abstractions
{
    public interface IPortfolioDataService
    {
        public Task<HomeInfoModel> GetHomeAsync();
        public Task<NavigationMenuInfoModel> GetNavigationMenuAsync();
        public Task<WhoAmIInfoModel> GetWhoAmIAsync();
        public Task<WorkShowcaseInfoModel> GetWorkShowcaseInfoAsync();
        public Task<ArticleModel> GetArticleByIdAsync(Guid articleId);
        public Task<ContactMeInfoModel> GetContactMeInfoAsync();
        public Task<SettingsInfoModel> GetSettingsAsync();
    }
}
