using PortfolioWebsite.BlazorUI.Models.ContactMe;
using PortfolioWebsite.BlazorUI.Models.WhoAmI;
using PortfolioWebsite.BlazorUI.Models.WorkShowcase;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class PortfolioDataModel
    {
        public WhoAmIInfoModel WhoAmI { get; set; }
        public WorkShowcaseInfoModel WorkShowcase { get; set; }
        public ContactMeInfoModel ContactMe { get; set; }
    }
}
