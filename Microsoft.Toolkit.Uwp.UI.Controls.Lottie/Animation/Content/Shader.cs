namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content
{
    internal abstract class Shader
    {
        public Matrix3X3 LocalMatrix { get; set; } = Matrix3X3.CreateIdentity();
    }
}