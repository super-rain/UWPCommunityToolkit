namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Parser
{
    internal class FloatParser : IValueParser<float?>
    {
        public static readonly FloatParser Instance = new FloatParser();

        public float? Parse(JsonReader reader, float scale)
        {
            return JsonUtils.ValueFromObject(reader) * scale;
        }
    }
}
