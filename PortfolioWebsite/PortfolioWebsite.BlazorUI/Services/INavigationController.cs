using PortfolioWebsite.BlazorUI.Models;
using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Services
{
    interface INavigationController
    {
        public string JsonNavigationLinks { get; set; }
        public List<NavigationLinkModel> NavigationLinks { get; set; }
        public void InitializeLinks();
    }
}
