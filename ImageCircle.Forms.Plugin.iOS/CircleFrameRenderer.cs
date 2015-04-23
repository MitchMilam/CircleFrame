using System;
using System.ComponentModel;
using CircledFrame.Forms.Plugin.Abstractions;
using CircledFrame.Forms.Plugin.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircleFrame), typeof(CircleFrameRenderer))]
namespace CircledFrame.Forms.Plugin.iOS
{
    /// <summary>
    /// CircleFrame Implementation
    /// </summary>
    public class CircleFrameRenderer : VisualElementRenderer<Frame>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            CreateCircle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == CircleFrame.BorderColorProperty.PropertyName ||
                e.PropertyName == CircleFrame.BorderThicknessProperty.PropertyName)
            {
                CreateCircle();
            }
        }

        private void CreateCircle()
        {
            var min = Math.Min(Element.Width, Element.Height);

            Layer.CornerRadius = (float)(min / 2.0);
            Layer.MasksToBounds = false;
            Layer.BorderColor = ((CircleFrame)Element).BorderColor.ToCGColor();
            Layer.BorderWidth = ((CircleFrame)Element).BorderThickness;
            
            ClipsToBounds = true;
        }
    }
}
