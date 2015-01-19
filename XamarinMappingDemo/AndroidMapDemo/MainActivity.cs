using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Support.V4.App;
using Android.Gms.Maps.Model;

namespace AndroidMapDemo
{
    [Activity(Label = "AndroidMapDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        private static LatLng AtlantaCoords = new LatLng(33.755, -84.39);
        private static LatLng VegasCoords = new LatLng(36.1215, -115.1739);

        private GoogleMap _map;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);                      

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            _map = mapFragment.Map;

            _map.MapType = GoogleMap.MapTypeHybrid;

            _map.UiSettings.RotateGesturesEnabled = false;
            _map.UiSettings.ZoomControlsEnabled = false;
            // etc ..

            _map.UiSettings.MyLocationButtonEnabled = true;
            _map.MyLocationEnabled = true;

            SetupMarkers();
            SetupOverlays();
        }

        private void SetupMarkers()
        {
            var marker1 = new MarkerOptions();
            marker1.SetPosition(AtlantaCoords);
            marker1.SetTitle("Atlanta");
            marker1.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueGreen));

            var marker2 = new MarkerOptions();
            marker2.SetPosition(VegasCoords);
            marker2.SetTitle("Vegas");
            marker2.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));

            _map.AddMarker(marker1);
            _map.AddMarker(marker2);
        }

        private void SetupOverlays()
        {
            // render a circle on the map
            CircleOptions circleOptions = new CircleOptions();
            circleOptions.InvokeCenter(AtlantaCoords);
            circleOptions.InvokeRadius(8000.0);
            circleOptions.InvokeFillColor(Android.Graphics.Color.Orange);
            _map.AddCircle(circleOptions);

            // render a polygon on the map
            PolygonOptions polygonOptions = new PolygonOptions();
            polygonOptions.Add(new LatLng[]
            {
                new LatLng(25.25, -80.27),
                new LatLng(32.14, -64.97),
                new LatLng(18.23, -66.56)
            });

            polygonOptions.InvokeFillColor(Android.Graphics.Color.Yellow);
            polygonOptions.InvokeStrokeWidth(8);
            _map.AddPolygon(polygonOptions);

            // overlay images at physical size: _map.AddGroundOverlay
        }
    }
}   