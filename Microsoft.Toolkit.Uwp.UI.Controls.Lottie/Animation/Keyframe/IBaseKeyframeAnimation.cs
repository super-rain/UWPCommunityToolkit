using System;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Value;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Keyframe
{
    public interface IBaseKeyframeAnimation
    {
        float Progress { get; set; }

        event EventHandler ValueChanged;

        void OnValueChanged();
    }

    public interface IBaseKeyframeAnimation<out TK, TA> : IBaseKeyframeAnimation
    {
        TA Value { get; }

        void SetValueCallback(ILottieValueCallback<TA> valueCallback);
    }
}