using System.Numerics;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Parser
{
    internal class PathParser : IValueParser<Vector2?>
    {
        public static readonly PathParser Instance = new PathParser();

        public Vector2? Parse(JsonReader reader, float scale)
        {
            return JsonUtils.JsonToPoint(reader, scale);
        }
    }
}
