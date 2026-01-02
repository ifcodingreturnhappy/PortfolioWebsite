namespace PortfolioWebsite.BlazorUI.Models.Theme
{
    public class ColorInfoModel
    {
        public string DisplayName { get; set; }
        public string CssVarName { get; set; }
        public string Hex { get; set; }
        public string DefaultHex { get; set; }

        public void UpdateColor(string hex)
        {
            this.Hex = hex;
        }

        public bool IsOnDefaultColor()
        {
            return this.Hex == this.DefaultHex;
        }
    }
}
