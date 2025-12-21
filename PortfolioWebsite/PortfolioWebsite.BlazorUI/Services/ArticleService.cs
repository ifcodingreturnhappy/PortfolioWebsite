using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PortfolioWebsite.BlazorUI.Abstractions;
using PortfolioWebsite.BlazorUI.Models;
using PortfolioWebsite.BlazorUI.Models.ContactMe;
using PortfolioWebsite.BlazorUI.Models.Home;
using PortfolioWebsite.BlazorUI.Models.Navigation;
using PortfolioWebsite.BlazorUI.Models.WhoAmI;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase.Articles;

// TODO: improve performance: cache articles after first load
// TODO: rename wwwroot paths to be full lowercase

namespace PortfolioWebsite.BlazorUI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient httpClient;
        private readonly IJsonSerializer jsonSerializer;

        const string articleFilePath = $"data/portfolio.json";

        private PortfolioDataModel portfolioDataModel;

        public ArticleService(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            this.httpClient = httpClient;
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<HomeInfoModel> GetHomeAsync()
        {
            await this.GetPortfolioDataAsync();
            return this.portfolioDataModel.Home;
        }

        public async Task<NavigationMenuInfoModel> GetNavigationMenuAsync()
        {
            await this.GetPortfolioDataAsync();
            return this.portfolioDataModel.NavigationMenu;
        }

        public async Task<WhoAmIInfoModel> GetWhoAmIAsync()
        {
            await this.GetPortfolioDataAsync();
            return this.portfolioDataModel.WhoAmI;
        }

        public async Task<WorkShowcaseInfoModel> GetWorkShowcaseInfoAsync()
        {
            await this.GetPortfolioDataAsync();
            return this.portfolioDataModel.WorkShowcase;
        }

        public async Task<ArticleModel> GetArticleByIdAsync(Guid articleId)
        {
            await this.GetPortfolioDataAsync();
            var article = this.portfolioDataModel.WorkShowcase.Articles.Single(x => x.Id.Equals(articleId));
            return article;
        }

        public async Task<ContactMeInfoModel> GetContactMeInfoAsync()
        {
            await this.GetPortfolioDataAsync();
            return this.portfolioDataModel.ContactMe;
        }

        private async Task GetPortfolioDataAsync()
        {
            var metadataJson = await this.httpClient.GetStringAsync($"{articleFilePath}?v={DateTime.Now.Ticks}");

            this.portfolioDataModel = this.jsonSerializer.Deserialize<PortfolioDataModel>(metadataJson);

            // TODO: remove delay and cache results after first load
            await Task.Delay(300);
        }
    }
}
