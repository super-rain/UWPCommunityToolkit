using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie
{
    public abstract class ColorFilter
    {
        public abstract ICanvasBrush Apply(BitmapCanvas dst, ICanvasBrush brush);
    }
}