using System;
using System.Drawing;

using Foundation;
using UIKit;
using MapKit;
using CoreLocation;

namespace IOSMapDemo
{
    public partial class IOSMapDemoViewController : UIViewController
    {
        private const double METERS_IN_A_MILE = 1609.34;

        private static CLLocationCoordinate2D AtlantaCoords = new CLLocationCoordinate2D(33.755, -84.39);
        private static CLLocationCoordinate2D VegasCoords = new CLLocationCoordinate2D(36.1215, -115.1739);

        public IOSMapDemoViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            // Perform any additional setup after loading the view, typically from a nib.

            MyMapView.Delegate = new MapDelegate();

//            MyMapView.MapType = MapKit.MKMapType.Satellite;
//            MyMapView.ZoomEnabled = false;
//            MyMapView.ScrollEnabled = false;

            AddAnnotations();
            AddOverlays();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            ZoomVegas();
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion

        private void ZoomVegas()
        {
            MyMapView.SetRegion(new MapKit.MKCoordinateRegion(
                VegasCoords, 
                new MapKit.MKCoordinateSpan(5, 5)), 
                true);
        }

        private void AddAnnotations()
        {
            var dot = new MKPointAnnotation();
            dot.Title = "Test Annotation";
            dot.SetCoordinate(VegasCoords);

            MyMapView.AddAnnotation(dot);
        }

        private void AddOverlays()
        {
            var circle = MKCircle.Circle(AtlantaCoords, 100 * METERS_IN_A_MILE);
            MyMapView.AddOverlay(circle);

            var poly = MKPolygon.FromCoordinates(new CLLocationCoordinate2D[]
            {
                new CLLocationCoordinate2D(25.25, -80.27),
                new CLLocationCoordinate2D(32.14, -64.97),
                new CLLocationCoordinate2D(18.23, -66.56)
            });
            MyMapView.AddOverlay(poly);
        }
    }

    class MapDelegate : MKMapViewDelegate
    {
        public override MKOverlayView GetViewForOverlay(MKMapView mapView, IMKOverlay overlay)
        {
            if (overlay is MKCircle)
            {
                MKCircleView cv = new MKCircleView(overlay as MKCircle);
                cv.FillColor = UIColor.Purple;
                cv.Alpha = 0.5f;
                return cv;
            }
            if (overlay is MKPolygon)
            {
                // return a view for the polygon
                MKPolygon polygon = overlay as MKPolygon;
                MKPolygonView polygonView = new MKPolygonView(polygon);
                polygonView.FillColor = UIColor.Blue;
                polygonView.StrokeColor = UIColor.Red;
                return polygonView;
            }

            return null;
        }
    }
}   