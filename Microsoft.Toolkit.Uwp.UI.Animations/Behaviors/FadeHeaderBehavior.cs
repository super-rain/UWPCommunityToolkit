﻿// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

namespace Microsoft.Toolkit.Uwp.UI.Animations.Behaviors
{
    using Microsoft.Xaml.Interactivity;
    using Windows.Foundation.Metadata;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Hosting;

    /// <summary>
    /// Performs an fade animation on a ListView or GridView Header using composition.
    /// </summary>
    /// <seealso>
    ///     <cref>Microsoft.Xaml.Interactivity.Behavior{Windows.UI.Xaml.UIElement}</cref>
    /// </seealso>
    public class FadeHeaderBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// Called after the behavior is attached to the <see cref="P:Microsoft.Xaml.Interactivity.Behavior.AssociatedObject" />.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the <see cref="P:Microsoft.Xaml.Interactivity.Behavior.AssociatedObject" />
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssignFadeAnimation();
        }

        /// <summary>
        /// If any of the properties are changed then the animation is automatically started depending on the AutomaticallyStart property.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var b = d as FadeHeaderBehavior;
            b?.AssignFadeAnimation();
        }

        /// <summary>
        /// The UIElement that will be faded.
        /// </summary>
        public static readonly DependencyProperty HeaderElementProperty = DependencyProperty.Register(
            "HeaderElement", typeof(UIElement), typeof(FadeHeaderBehavior), new PropertyMetadata(null, PropertyChangedCallback));

        /// <summary>
        /// Gets or sets the target element for the Fading behavior.
        /// </summary>
        /// <remarks>
        /// Set this using the header of a ListView or GridView. You can use the entire root of the header or an element within the header.
        /// 
        /// Using this example Header:
        /// <ListView.Header>
        ///     <Grid Name="MyHeader">
        ///     </Grid>
        /// </ListView.Header>
        ///
        /// The behavior would be implemented like this
        /// <FadeHeaderBehavior HeaderElement="{Binding ElementName=HeaderPanel}" />
        /// </remarks>
        public UIElement HeaderElement
        {
            get { return (UIElement)GetValue(HeaderElementProperty); }
            set { SetValue(HeaderElementProperty, value); }
        }

        private void AssignFadeAnimation()
        {
            // Confirm that Windows.UI.Xaml.Hosting.ElementCompositionPreview is available (Windows 10 10586 or later).
            if (!ApiInformation.IsMethodPresent("Windows.UI.Xaml.Hosting.ElementCompositionPreview", nameof(ElementCompositionPreview.GetScrollViewerManipulationPropertySet)))
            {
                return;
            }

            if (AssociatedObject == null)
            {
                return;
            }

            var scroller = AssociatedObject as ScrollViewer ?? AssociatedObject.FindDescendant<ScrollViewer>();

            if (scroller == null)
            {
                return;
            }

            var scrollerViewerManipulation = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(scroller);
            var compositor = scrollerViewerManipulation.Compositor;

            // Use the ScrollViewer's Y offset and the header's height to calculate the opacity percentage. Clamp it between 0% and 100%
            var opacityExpression = compositor.CreateExpressionAnimation("Clamp(1 - (-ScrollManipululation.Translation.Y / HeaderHeight), 0, 1)");

            // Get the ScrollViewerManipulation Reference
            opacityExpression.SetReferenceParameter("ScrollManipululation", scrollerViewerManipulation);

            // Pass in the height of the header as a Scalar
            opacityExpression.SetScalarParameter("HeaderHeight", (float)HeaderElement.RenderSize.Height);

            // Begin animating
            var targetElement = ElementCompositionPreview.GetElementVisual(HeaderElement);
            targetElement.StartAnimation("Opacity", opacityExpression);
        }
    }
}
