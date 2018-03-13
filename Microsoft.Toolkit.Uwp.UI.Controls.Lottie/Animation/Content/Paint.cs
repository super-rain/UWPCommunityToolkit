using Microsoft.Graphics.Canvas.Geometry;
using Windows.UI;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content
{
    public class Paint
    {
        public const int AntiAliasFlag = 0b01;
        public const int FilterBitmapFlag = 0b10;

        public int Flags { get; }

        public Paint(int flags)
        {
            Flags = flags;
        }

        public Paint()
            : this(0)
        {
        }

        public enum PaintStyle
        {
            Fill,
            Stroke
        }

        public byte Alpha
        {
            get => Color.A;
            set
            {
                var color = Color;
                color.A = value;
                Color = color;
            }
        }

        public Color Color { get; set; } = Colors.Transparent;

        public PaintStyle Style { get; set; }

        public ColorFilter ColorFilter { get; set; }

        public CanvasCapStyle StrokeCap { get; set; }

        public CanvasLineJoin StrokeJoin { get; set; }

        public float StrokeWidth { get; set; }

        public PathEffect PathEffect { get; set; }

        public PorterDuffXfermode Xfermode { get; set; }

        internal Shader Shader { get; set; }

        public Typeface Typeface { get; set; }

        public float TextSize { get; set; }
    }
}