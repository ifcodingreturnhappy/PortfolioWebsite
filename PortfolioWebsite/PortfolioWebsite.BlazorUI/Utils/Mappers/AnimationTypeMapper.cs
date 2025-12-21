using System;
using PortfolioWebsite.BlazorUI.Models.Common;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class AnimationTypeMapper
    {
        public static string ToCss(this AnimationType animationType) => animationType switch
        {
            AnimationType.None => string.Empty,
            AnimationType.VP_ANIM_1 => "vp-anim-1",
            AnimationType.VP_ANIM_2 => "vp-anim-2",
            AnimationType.VP_ANIM_3 => "vp-anim-3",
            AnimationType.VP_ANIM_4 => "vp-anim-4",
            AnimationType.VP_ANIM_5 => "vp-anim-5",
            _ => throw new NotImplementedException($"Mapping for AnimationType '{animationType}' is not implemented."),
        };
    }
}
