using PortfolioWebsite.BlazorUI.Games.Logic;

namespace PortfolioWebsite.BlazorUI.Models
{
    public class GameDisplayModel
    {
        public string DisplayImagePath { get; set; }
        public IGame Game { get; set; }
    }
}
