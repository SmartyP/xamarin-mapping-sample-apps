using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapDemoApp
{
    public class App : Application
    {
        private static Position AtlantaCoords = new Position(33.755, -84.39);
        private static Position VegasCoords = new Position(36.1215, -115.1739);

        private Map _map;

        public App()
        {
            _map = new Map(MapSpan.FromCenterAndRadius(AtlantaCoords, Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                MapType = MapType.Street
            };

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Spacing = 0,
                    Children =
                    {
                        _map
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            PlacePins();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void PlacePins()
        {
            var pin = new Pin {
                Type = PinType.Place,
                Position = VegasCoords,
                Label = "Vegas",
                Address = "Blackjack Table Way"
            };
            _map.Pins.Add(pin);
        }
    }
}

