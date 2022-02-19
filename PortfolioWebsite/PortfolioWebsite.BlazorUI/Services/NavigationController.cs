using Newtonsoft.Json;
using PortfolioWebsite.BlazorUI.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class NavigationController : INavigationController
    {
        private readonly string navigationLinksFilePath = "/Data/NavigationLinks.json";

        public List<NavigationLinkModel> NavigationLinks { get; set; }

        private readonly HttpClient _client;

        public NavigationController(HttpClient client)
        {
            _client = client;
            NavigationLinks = new List<NavigationLinkModel>();
        }

        public async Task InitializeLinks()
        {
            try
            {
                var json = await _client.GetStringAsync(navigationLinksFilePath);

                //string json = File.ReadAllText($"{_env.WebRootPath}{navigationLinksFilePath}");
                NavigationLinks = JsonConvert.DeserializeObject<List<NavigationLinkModel>>(json);
            }
            catch
            {
            }
        }


    }
}
