using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content
{
    internal abstract class Gradient : Shader
    {
        public abstract ICanvasBrush GetBrush(CanvasDevice device, byte alpha);
    }
}