using Newtonsoft.Json;
using PortfolioWebsite.BlazorUI.Models;
using System.Collections.Generic;
using System.IO;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class NavigationController : INavigationController
    {
        readonly string navigationLinksFilePath = "wwwroot/Data/NavigationLinks.json";
        public List<NavigationLinkModel> NavigationLinks { get; set; }

        public void InitializeLinks()
        {
            string json = File.ReadAllText(navigationLinksFilePath);
            NavigationLinks = JsonConvert.DeserializeObject<List<NavigationLinkModel>>(json);
        }
    }
}
