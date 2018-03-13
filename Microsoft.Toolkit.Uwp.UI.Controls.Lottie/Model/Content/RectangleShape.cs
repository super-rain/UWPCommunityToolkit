﻿using System.Numerics;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Animatable;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Layer;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Content
{
    public class RectangleShape : IContentModel
    {
        private readonly IAnimatableValue<Vector2?, Vector2?> _position;
        private readonly AnimatablePointValue _size;
        private readonly AnimatableFloatValue _cornerRadius;

        public RectangleShape(string name, IAnimatableValue<Vector2?, Vector2?> position, AnimatablePointValue size, AnimatableFloatValue cornerRadius)
        {
            Name = name;
            _position = position;
            _size = size;
            _cornerRadius = cornerRadius;
        }

        internal virtual string Name { get; }

        internal virtual AnimatableFloatValue CornerRadius => _cornerRadius;

        internal virtual AnimatablePointValue Size => _size;

        internal virtual IAnimatableValue<Vector2?, Vector2?> Position => _position;

        public IContent ToContent(LottieDrawable drawable, BaseLayer layer)
        {
            return new RectangleContent(drawable, layer, this);
        }

        public override string ToString()
        {
            return "RectangleShape{position=" + _position + ", size=" + _size + '}';
        }
    }
}