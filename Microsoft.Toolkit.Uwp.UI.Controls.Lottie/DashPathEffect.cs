using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie
{
    internal class DashPathEffect : PathEffect
    {
        private readonly float[] _intervals;
        private readonly float _phase;

        public DashPathEffect(float[] intervals, float phase)
        {
            _intervals = intervals;
            _phase = phase;
        }

        public override void Apply(CanvasStrokeStyle canvasStrokeStyle, Paint paint)
        {
            if (paint.Style == Paint.PaintStyle.Stroke)
            {
                canvasStrokeStyle.CustomDashStyle = _intervals;
                canvasStrokeStyle.DashOffset = _phase;
            }
        }
    }
}