using System.Collections.Generic;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Utils;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Value;
using Windows.UI;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Keyframe
{
    internal class ColorKeyframeAnimation : KeyframeAnimation<Color?>
    {
        internal ColorKeyframeAnimation(List<Keyframe<Color?>> keyframes)
            : base(keyframes)
        {
        }

        public override Color? GetValue(Keyframe<Color?> keyframe, float keyframeProgress)
        {
            if (keyframe.StartValue == null || keyframe.EndValue == null)
            {
                throw new System.InvalidOperationException("Missing values for keyframe.");
            }

            var startColor = keyframe.StartValue;
            var endColor = keyframe.EndValue;

            if (valueCallback != null)
            {
                return valueCallback.GetValueInternal(keyframe.StartFrame.Value, keyframe.EndFrame.Value, startColor, endColor, keyframeProgress, LinearCurrentKeyframeProgress, Progress);
            }

            return GammaEvaluator.Evaluate(keyframeProgress, startColor.Value, endColor.Value);
        }
    }
}