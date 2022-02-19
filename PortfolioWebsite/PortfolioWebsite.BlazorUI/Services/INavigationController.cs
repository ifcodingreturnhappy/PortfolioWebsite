using PortfolioWebsite.BlazorUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Services
{
    interface INavigationController
    {
        public List<NavigationLinkModel> NavigationLinks { get; set; }
        public Task InitializeLinks();
    }
}
