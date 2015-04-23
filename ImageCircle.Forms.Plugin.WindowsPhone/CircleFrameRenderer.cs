using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using Windows.UI.Core;
using CircledFrame.Forms.Plugin.Abstractions;
using CircledFrame.Forms.Plugin.WindowsPhone;
using Xamarin.Forms;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using Color = System.Windows.Media.Color;
using Frame = Xamarin.Forms.Frame;
using Point = System.Windows.Point;

[assembly: ExportRenderer(typeof(CircleFrame), typeof(CircleFrameRenderer))]

namespace CircledFrame.Forms.Plugin.WindowsPhone
{
    /// <summary>
    ///     CircleFrame Implementation
    /// </summary>
    public class CircleFrameRenderer : VisualElementRenderer<Frame, Border>
        //ViewRenderer<Frame, Border>
    {
        /// <summary>
        ///     Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            var min = Math.Min(Element.WidthRequest, Element.HeightRequest) / 2.0f;

            var border = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)),
                //Height = Element.HeightRequest,
                //Width = Element.WidthRequest,
                Clip = new EllipseGeometry
                {
                    Center = new Point(min, min),
                    RadiusX = min,
                    RadiusY = min
                },
                //Child = (UIElement) Element
            };

            SetNativeControl(border);
            //PackChild();
            //UpdateBorder();

            //CreateCircle();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Content")
            {
                PackChild();
                return;
            }

            if (e.PropertyName != VisualElement.HeightProperty.PropertyName &&
                e.PropertyName != VisualElement.WidthProperty.PropertyName &&
                e.PropertyName != CircleFrame.BorderColorProperty.PropertyName &&
                e.PropertyName != CircleFrame.BorderThicknessProperty.PropertyName)
            {
                return;
            }

            if (Control == null )   //|| Control.Clip != null)
            {
                return;
            }

            //CreateCircle();

            //var min = Math.Min(Element.Width, Element.Height) / 2.0f;

            //if (min <= 0)
            //{
            //    return;
            //}

            //Control.CornerRadius = new CornerRadius(min);

            //Control.Clip = new EllipseGeometry
            //{
            //    Center = new Point(min, min),
            //    RadiusX = min,
            //    RadiusY = min
            //};
        }

        private void CreateCircle()
        {
            var min = Math.Min(Element.Width, Element.Height);

            if (min <= 0)
            {
                return;
            }

            Control.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
            

           // Control.CornerRadius = new CornerRadius(min);

            Control.Clip = new EllipseGeometry
            {
                Center = new Point(min, min),
                RadiusX = min,
                RadiusY = min
            };
        }

        private void PackChild()
        {
            if (Element.Content == null)
            {
                return;
            }
            if (Element.Content.GetRenderer() == null)
            {
                Element.Content.SetRenderer(RendererFactory.GetRenderer(Element.Content));
            }
            var renderer = Element.Content.GetRenderer() as UIElement;
            Control.Child = renderer;
        }

        private void UpdateBorder()
        {
            Control.CornerRadius = new CornerRadius(5);

            //if (Element.OutlineColor ==  Xamarin.Forms.Color.Default)
            //{
            //    Control.BorderBrush = new  SolidColorBrush(Xamarin.Forms.Color(0, 0, 0, 0);

            //    return;
            //}

            //Control.BorderBrush = new SolidColorBrush(Element.OutlineColor);

            //Control.BorderThickness = new Xamarin.Forms.Thickness(1);
        }
    }


}