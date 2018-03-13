﻿using System.Diagnostics;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Content;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Parser
{
    internal static class ContentModelParser
    {
        internal static IContentModel Parse(JsonReader reader, LottieComposition composition)
        {
            string type = null;

            reader.BeginObject();
            while (reader.HasNext())
            {
                if (reader.NextName().Equals("ty"))
                {
                    type = reader.NextString();
                    break;
                }
                else
                {
                    reader.SkipValue();
                }
            }

            if (type == null)
            {
                return null;
            }

            IContentModel model = null;
            switch (type)
            {
                case "gr":
                    model = ShapeGroupParser.Parse(reader, composition);
                    break;
                case "st":
                    model = ShapeStrokeParser.Parse(reader, composition);
                    break;
                case "gs":
                    model = GradientStrokeParser.Parse(reader, composition);
                    break;
                case "fl":
                    model = ShapeFillParser.Parse(reader, composition);
                    break;
                case "gf":
                    model = GradientFillParser.Parse(reader, composition);
                    break;
                case "tr":
                    model = AnimatableTransformParser.Parse(reader, composition);
                    break;
                case "sh":
                    model = ShapePathParser.Parse(reader, composition);
                    break;
                case "el":
                    model = CircleShapeParser.Parse(reader, composition);
                    break;
                case "rc":
                    model = RectangleShapeParser.Parse(reader, composition);
                    break;
                case "tm":
                    model = ShapeTrimPathParser.Parse(reader, composition);
                    break;
                case "sr":
                    model = PolystarShapeParser.Parse(reader, composition);
                    break;
                case "mm":
                    model = MergePathsParser.Parse(reader);
                    composition.AddWarning("Animation contains merge paths. Merge paths are only " +
                        "supported on KitKat+ and must be manually enabled by calling " +
                        "enableMergePathsForKitKatAndAbove().");
                    break;
                case "rp":
                    model = RepeaterParser.Parse(reader, composition);
                    break;
                default:
                    Debug.WriteLine("Unknown shape type " + type, LottieLog.Tag);
                    break;
            }

            while (reader.HasNext())
            {
                reader.SkipValue();
            }

            reader.EndObject();

            return model;
        }
    }
}
