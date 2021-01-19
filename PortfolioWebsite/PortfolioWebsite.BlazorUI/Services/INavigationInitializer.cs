using PortfolioWebsite.BlazorUI.Models;
using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Services
{
    interface INavigationInitializer
    {
        public List<NavigationLinkModel> InitializeLinks();
    }
}
