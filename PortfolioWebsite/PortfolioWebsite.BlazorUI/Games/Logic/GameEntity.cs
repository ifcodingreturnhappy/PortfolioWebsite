namespace PortfolioWebsite.BlazorUI.Games.Logic
{
    public class GameEntity
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string AltText { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Position_X { get; set; } // In percentage (of screen), not px
        public double Position_Y { get; set; } // In percentage (of screen), not px
    }
}
