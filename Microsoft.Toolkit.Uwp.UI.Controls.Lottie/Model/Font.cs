namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model
{
    public class Font
    {
        public Font(string family, string name, string style, float ascent)
        {
            Family = family;
            Name = name;
            Style = style;
            _ascent = ascent;
        }

        public string Family { get; }

        public string Name { get; }

        public string Style { get; }

        internal float Ascent => _ascent;

        private readonly float _ascent;
    }
}
