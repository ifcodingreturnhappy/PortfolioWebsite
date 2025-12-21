using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Models.Home
{
    public class HomeInfoModel
    {
        public string FirstLineTitle { get; set; }
        public string SecondLineTitle { get; set; }
        public string MainTitle { get; set; }
        public string AnimatedMainTitle { get; set; }
        public string Subtitle { get; set; }
        public IEnumerable<string> SubtitleDescriptions { get; set; }
    }
}
