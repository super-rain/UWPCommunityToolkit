using System.Collections.Generic;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Keyframe;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Value;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Animatable
{
    public class AnimatableFloatValue : BaseAnimatableValue<float?, float?>
    {
        internal AnimatableFloatValue()
            : base(0f)
        {
        }

        public AnimatableFloatValue(List<Keyframe<float?>> keyframes)
            : base(keyframes)
        {
        }

        public override IBaseKeyframeAnimation<float?, float?> CreateAnimation()
        {
            return new FloatKeyframeAnimation(Keyframes);
        }
    }
}