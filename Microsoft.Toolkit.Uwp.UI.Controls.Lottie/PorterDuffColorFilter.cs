using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content;
using Windows.UI;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie
{
    public abstract class PorterDuffColorFilter : ColorFilter
    {
        public Color Color { get; }

        public PorterDuff.Mode Mode { get; }

        protected PorterDuffColorFilter(Color color, PorterDuff.Mode mode)
        {
            Color = color;
            Mode = mode;
        }

        public override ICanvasBrush Apply(BitmapCanvas dst, ICanvasBrush brush)
        {
            // var originalColor = Colors.White;
            // if (brush is CompositionColorBrush compositionColorBrush)
            //    originalColor = compositionColorBrush.Color;
            // TODO
            return brush;
        }
    }
}