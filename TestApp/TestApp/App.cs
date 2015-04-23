using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CircledFrame.Forms.Plugin.Abstractions;

using Xamarin.Forms;

namespace TestApp
{
    public class App : Application
    {
        public App()
        {
            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Image
                    {
                        Aspect = Aspect.AspectFit,
                        Source = "CostaRicanFrog.jpg",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                    },
                    new Label
                    {
                        Text = "Costa Rican Frog",
                        TextColor = Color.White,
                        XAlign = TextAlignment.Center,
                        FontSize = 12,
                    }
                }
            };

            // The root page of your application
            MainPage = new ContentPage
            {
                BackgroundColor = Color.White,
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						},
                        new CircleFrame
                        {
                           // IsClippedToBounds = true,
                            BackgroundColor = Color.Black,
                            BorderColor = Color.Red,
                            BorderThickness = 5,
                            HeightRequest = 150,
                            WidthRequest = 150,
                            HasShadow = true,
                            //Aspect = Aspect.AspectFill,
                            HorizontalOptions = LayoutOptions.Center,
                            Content =stack
                        }
					}
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
