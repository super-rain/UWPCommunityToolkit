namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie
{
    public interface IAnimatable
    {
        bool IsRunning { get; }

        void Start();

        void Stop();
    }
}
