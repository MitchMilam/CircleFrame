using System;
using Android.Graphics;
using Android.OS;
using Android.Views;
using CircledFrame.Forms.Plugin.Abstractions;
using CircledFrame.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(CircleFrame), typeof(CircleFrameRenderer))]
namespace CircledFrame.Forms.Plugin.Droid
{
    /// <summary>
    /// CircleFrame Implementation
    /// </summary>
    public class CircleFrameRenderer : FrameRenderer
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

            if (e.OldElement != null)
            {
                return;
            }

            //Only enable hardware accelleration on lollipop
            if ((int)Build.VERSION.SdkInt < 21)
            {
                SetLayerType(LayerType.Software, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="child"></param>
        /// <param name="drawingTime"></param>
        /// <returns></returns>
        protected override bool DrawChild(Canvas canvas, View child, long drawingTime)
        {
            try
            {
                var radius = Math.Min(Width, Height) / 2;
                var strokeWidth = 10;

                radius -= strokeWidth / 2;


                var path = new Path();

                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

                canvas.Save();
                canvas.ClipPath(path);

                var result = base.DrawChild(canvas, child, drawingTime);
                
                canvas.Restore();

                path = new Path();

                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

                var paint = new Paint
                {
                    AntiAlias = true,
                    StrokeWidth = ((CircleFrame) Element).BorderThickness,
                    Color = ((CircleFrame) Element).BorderColor.ToAndroid()
                };

                paint.SetStyle(Paint.Style.Stroke);

                canvas.DrawPath(path, paint);

                paint.Dispose();
                path.Dispose();

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}
