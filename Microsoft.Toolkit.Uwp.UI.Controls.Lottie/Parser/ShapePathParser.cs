using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Animatable;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Content;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Parser
{
    internal static class ShapePathParser
    {
        internal static ShapePath Parse(JsonReader reader, LottieComposition composition)
        {
            string name = null;
            int ind = 0;
            AnimatableShapeValue shape = null;

            while (reader.HasNext())
            {
                switch (reader.NextName())
                {
                    case "nm":
                        name = reader.NextString();
                        break;
                    case "ind":
                        ind = reader.NextInt();
                        break;
                    case "ks":
                        shape = AnimatableValueParser.ParseShapeData(reader, composition);
                        break;
                    default:
                        reader.SkipValue();
                        break;
                }
            }

            return new ShapePath(name, ind, shape);
        }
    }
}
