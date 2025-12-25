using PortfolioWebsite.BlazorUI.Models.ContactMe;
using PortfolioWebsite.BlazorUI.Models.Home;
using PortfolioWebsite.BlazorUI.Models.Navigation;
using PortfolioWebsite.BlazorUI.Models.Settings;
using PortfolioWebsite.BlazorUI.Models.WhoAmI;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class PortfolioDataModel
    {
        public HomeInfoModel Home { get; set; }
        public NavigationMenuInfoModel NavigationMenu { get; set; }
        public WhoAmIInfoModel WhoAmI { get; set; }
        public WorkShowcaseInfoModel WorkShowcase { get; set; }
        public ContactMeInfoModel ContactMe { get; set; }
        public SettingsInfoModel Settings { get; set; }
    }
}
