using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PortfolioWebsite.BlazorUI.Abstractions;
using PortfolioWebsite.BlazorUI.Models;

// TODO: rename models / method names after refactor

namespace PortfolioWebsite.BlazorUI.Services
{
    public class ArticleStore : IArticleStore
    {
        private readonly HttpClient httpClient;
        private readonly IJsonSerializer jsonSerializer;

        // TODO: don't fetch data using http, its slower, just have it here.
        const string articleFilePath = $"Data/portfolio.json";

        private PortfolioDataModel portfolioDataModel;

        public ArticleStore(HttpClient httpClient, IJsonSerializer jsonSerializer)
        {
            this.httpClient = httpClient;
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<WhoAmIInfoModel> GetWhoAmIAsync()
        {
            await this.GetArticleMetadataAsync();
            return this.portfolioDataModel.WhoAmI;
        }

        public async Task<IEnumerable<ArticleMetadataModel>> GetArticleMetadataAsync()
        {
            // TODO: remove ticks
            var metadataJson = await this.httpClient.GetStringAsync($"{articleFilePath}?v={DateTime.Now.Ticks}");

            this.portfolioDataModel = this.jsonSerializer.Deserialize<PortfolioDataModel>(metadataJson);

            await Task.Delay(300);

            var articlesMetadata = this.portfolioDataModel.WorkShowcase.ArticleMetadata.OrderByDescending(x => x.PublishDate).ToList();

            return articlesMetadata;
        }

        public Task<IEnumerable<ArticleTagModel>> GetAvailableTagsAsync()
        {
            // TODO: this shouldnt know that the articles need to be loaded first
            var tags = this.portfolioDataModel.WorkShowcase.ArticleMetadata.SelectMany(x => x.Tags)
                                                                           .Distinct()
                                                                           .Select(x => new ArticleTagModel { IsSelected = true, Name = x })
                                                                           .ToList();

            return Task.FromResult((IEnumerable<ArticleTagModel>)tags);
        }

        public async Task<ArticleModel> GetArticleByIdAsync(Guid articleId)
        {
            await this.GetArticleMetadataAsync();

            var article = this.portfolioDataModel.WorkShowcase.Articles.Single(x => x.Id.Equals(articleId));

            return article;
        }

        public async Task<ContactMeInfoModel> GetContactMeInfoAsync()
        {
            await this.GetArticleMetadataAsync();
            return this.portfolioDataModel.ContactMe;
        }
    }
}
