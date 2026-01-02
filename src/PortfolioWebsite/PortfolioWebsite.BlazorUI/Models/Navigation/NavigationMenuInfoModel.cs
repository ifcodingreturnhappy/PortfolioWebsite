using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Navigation
{
    public class NavigationMenuInfoModel
    {
        public string Title { get; set; }
        public string CollapsedMenuIcon { get; set; }
        public string OpenMenuIcon { get; set; }
        public IEnumerable<NavigationLinkInfoModel> NavigationLinks { get; set; }
    }
}
