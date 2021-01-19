using Newtonsoft.Json;
using PortfolioWebsite.BlazorUI.Models;
using System.Collections.Generic;
using System.IO;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class NavigationInitializer : INavigationInitializer
    {
        readonly string navigationLinksFilePath = "wwwroot/Data/NavigationLinks.json";


        //Alter this to read from json file
        public List<NavigationLinkModel> InitializeLinks()
        {
            string json = File.ReadAllText(navigationLinksFilePath);
            List<NavigationLinkModel> navigationLinks = JsonConvert.DeserializeObject<List<NavigationLinkModel>>(json);

            return navigationLinks;
        }
    }
}
