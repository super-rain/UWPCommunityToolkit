using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie
{
    public abstract class PathEffect
    {
        public abstract void Apply(CanvasStrokeStyle canvasStrokeStyle, Paint paint);
    }
}