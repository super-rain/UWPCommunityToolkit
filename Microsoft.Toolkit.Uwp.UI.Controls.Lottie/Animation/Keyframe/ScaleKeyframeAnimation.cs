using System;
using System.Collections.Generic;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Value;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Keyframe
{
    internal class ScaleKeyframeAnimation : KeyframeAnimation<ScaleXy>
    {
        internal ScaleKeyframeAnimation(List<Keyframe<ScaleXy>> keyframes)
            : base(keyframes)
        {
        }

        public override ScaleXy GetValue(Keyframe<ScaleXy> keyframe, float keyframeProgress)
        {
            if (keyframe.StartValue == null || keyframe.EndValue == null)
            {
                throw new InvalidOperationException("Missing values for keyframe.");
            }

            var startTransform = keyframe.StartValue;
            var endTransform = keyframe.EndValue;

            if (valueCallback != null)
            {
                return valueCallback.GetValueInternal(keyframe.StartFrame.Value, keyframe.EndFrame.Value, startTransform, endTransform, keyframeProgress, LinearCurrentKeyframeProgress, Progress);
            }

            return new ScaleXy(MathExt.Lerp(startTransform.ScaleX, endTransform.ScaleX, keyframeProgress), MathExt.Lerp(startTransform.ScaleY, endTransform.ScaleY, keyframeProgress));
        }
    }
}