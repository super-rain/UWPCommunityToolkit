namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Parser
{
    internal interface IValueParser<out T>
    {
        T Parse(JsonReader reader, float scale);
    }
}
