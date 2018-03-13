﻿using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Keyframe;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Value
{
    /// <summary>
    /// Allows you to set a callback on a resolved <see cref="Model.KeyPath"/> to modify its animation values at runtime.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LottieValueCallback<T> : ILottieValueCallback<T>
    {
        private readonly LottieFrameInfo<T> _frameInfo = new LottieFrameInfo<T>();

        private IBaseKeyframeAnimation _animation;

        /// <summary>
        /// This can be set with <see cref="SetValue(T)"/> to use a value instead of deferring
        /// to the callback.
        /// </summary>
        protected T value;

        public LottieValueCallback()
        {
        }

        public LottieValueCallback(T staticValue)
        {
            value = staticValue;
        }

        /// <summary>
        /// Override this if you haven't set a static value in the constructor or with SetValue.
        /// </summary>
        /// <param name="frameInfo"></param>
        /// <returns></returns>
        public virtual T GetValue(LottieFrameInfo<T> frameInfo)
        {
            return value;
        }

        public void SetValue(T value)
        {
            this.value = value;
            if (_animation != null)
            {
                _animation.OnValueChanged();
            }
        }

        public T GetValueInternal(
            float startFrame,
            float endFrame,
            T startValue,
            T endValue,
            float linearKeyframeProgress,
            float interpolatedKeyframeProgress,
            float overallProgress)
        {
            return GetValue(
                _frameInfo.Set(
                    startFrame,
                    endFrame,
                    startValue,
                    endValue,
                    linearKeyframeProgress,
                    interpolatedKeyframeProgress,
                    overallProgress));
        }

        public void SetAnimation(IBaseKeyframeAnimation animation)
        {
            _animation = animation;
        }
    }
}