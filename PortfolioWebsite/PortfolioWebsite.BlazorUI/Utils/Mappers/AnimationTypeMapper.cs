using System;
using PortfolioWebsite.BlazorUI.Models.Enums;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class AnimationTypeMapper
    {
        public static string ToCss(this AnimationType animationType) => animationType switch
        {
            AnimationType.None => string.Empty,
            AnimationType.FadeInLeftTranslate => "vp-anim-1",
            AnimationType.FadeInRightTranslate => "vp-anim-2",
            AnimationType.FadeInTopTranslate => "vp-anim-3",
            AnimationType.FadeInBottomTranslate => "vp-anim-4",
            AnimationType.FadeIn => "vp-anim-5",
            _ => throw new NotImplementedException($"Mapping for AnimationType '{animationType}' is not implemented."),
        };
    }
}
