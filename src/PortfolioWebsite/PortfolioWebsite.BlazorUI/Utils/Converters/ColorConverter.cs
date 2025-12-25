namespace PortfolioWebsite.BlazorUI.Utils.Converters
{
    public static class ColorConverter
    {
        public static string RgbToHex(string rgb)
        {
            var parts = rgb.Split(',');
            var r = int.Parse(parts[0].Trim());
            var g = int.Parse(parts[1].Trim());
            var b = int.Parse(parts[2].Trim());
            return $"#{r:X2}{g:X2}{b:X2}";
        }
    }
}
