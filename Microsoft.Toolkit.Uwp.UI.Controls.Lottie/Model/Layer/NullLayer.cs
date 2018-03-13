﻿using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content;
using Windows.Foundation;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Layer
{
    internal class NullLayer : BaseLayer
    {
        internal NullLayer(LottieDrawable lottieDrawable, Layer layerModel)
            : base(lottieDrawable, layerModel)
        {
        }

        public override void DrawLayer(BitmapCanvas canvas, Matrix3X3 parentMatrix, byte parentAlpha)
        {
            // Do nothing.
        }

        public override void GetBounds(out Rect outBounds, Matrix3X3 parentMatrix)
        {
            base.GetBounds(out outBounds, parentMatrix);
            RectExt.Set(ref outBounds, 0, 0, 0, 0);
        }
    }
}