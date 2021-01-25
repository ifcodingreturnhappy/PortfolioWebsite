using Newtonsoft.Json;
using PortfolioWebsite.BlazorUI.Models;
using System.Collections.Generic;
using System.IO;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class NavigationController : INavigationController
    {

        private readonly string navigationLinksFilePath = "wwwroot/Data/NavigationLinks.json";
        public string JsonNavigationLinks { get; set; }
        public List<NavigationLinkModel> NavigationLinks { get; set; }

        public void InitializeLinks()
        {
            JsonNavigationLinks = File.ReadAllText(navigationLinksFilePath);
            NavigationLinks = JsonConvert.DeserializeObject<List<NavigationLinkModel>>(JsonNavigationLinks);
        }


    }
}
