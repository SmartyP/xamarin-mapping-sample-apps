// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace IOSMapDemo
{
	[Register ("IOSMapDemoViewController")]
	partial class IOSMapDemoViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MapKit.MKMapView MyMapView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyMapView != null) {
				MyMapView.Dispose ();
				MyMapView = null;
			}
		}
	}
}
