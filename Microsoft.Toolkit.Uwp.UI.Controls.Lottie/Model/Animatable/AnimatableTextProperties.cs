namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Animatable
{
    public class AnimatableTextProperties
    {
        private readonly AnimatableColorValue color;
        private readonly AnimatableColorValue stroke;
        private readonly AnimatableFloatValue strokeWidth;
        private readonly AnimatableFloatValue tracking;

        internal AnimatableColorValue Color => color;

        internal AnimatableColorValue Stroke => stroke;

        internal AnimatableFloatValue StrokeWidth => strokeWidth;

        internal AnimatableFloatValue Tracking => tracking;

        public AnimatableTextProperties(AnimatableColorValue color, AnimatableColorValue stroke, AnimatableFloatValue strokeWidth, AnimatableFloatValue tracking)
        {
            this.color = color;
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
            this.tracking = tracking;
        }
    }
}
