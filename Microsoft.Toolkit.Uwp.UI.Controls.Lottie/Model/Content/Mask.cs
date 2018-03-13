﻿using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Animatable;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Content
{
    public class Mask
    {
        public enum MaskMode
        {
            MaskModeAdd,
            MaskModeSubtract,
            MaskModeIntersect
        }

        private readonly MaskMode _maskMode;

        public Mask(MaskMode maskMode, AnimatableShapeValue maskPath, AnimatableIntegerValue opacity)
        {
            _maskMode = maskMode;
            MaskPath = maskPath;
            Opacity = opacity;
        }

        internal virtual MaskMode GetMaskMode()
        {
            return _maskMode;
        }

        internal virtual AnimatableShapeValue MaskPath { get; }

        internal virtual AnimatableIntegerValue Opacity { get; }
    }
}