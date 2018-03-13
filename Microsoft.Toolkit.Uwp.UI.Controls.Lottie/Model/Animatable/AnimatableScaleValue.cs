using System.Collections.Generic;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Keyframe;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Value;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Animatable
{
    public class AnimatableScaleValue : BaseAnimatableValue<ScaleXy, ScaleXy>
    {
        internal AnimatableScaleValue()
            : this(new ScaleXy())
        {
        }

        public AnimatableScaleValue(ScaleXy value)
            : base(value)
        {
        }

        public AnimatableScaleValue(List<Keyframe<ScaleXy>> keyframes)
            : base(keyframes)
        {
        }

        public override IBaseKeyframeAnimation<ScaleXy, ScaleXy> CreateAnimation()
        {
            return new ScaleKeyframeAnimation(Keyframes);
        }
    }
}