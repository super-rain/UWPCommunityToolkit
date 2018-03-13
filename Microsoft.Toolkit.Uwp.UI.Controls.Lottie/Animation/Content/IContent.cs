using System.Collections.Generic;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Content
{
    public interface IContent
    {
        string Name { get; }

        void SetContents(List<IContent> contentsBefore, List<IContent> contentsAfter);
    }
}