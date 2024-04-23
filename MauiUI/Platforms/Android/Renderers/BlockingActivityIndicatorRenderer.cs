using Android.Content;
using Android.Views;
using Android.Widget;
using MauiUI.Controls;
using MauiUI.Platforms.Android.Renderers;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

//[assembly: ExportRenderer(typeof(BlockingActivityIndicator), typeof(BlockingActivityIndicatorRenderer))]
//namespace MauiUI.Platforms.Android.Renderers
//{
//    //public class BlockingActivityIndicatorRenderer : ViewRenderer<BlockingActivityIndicator, Android.Views.View>
//    //{
//    //    public BlockingActivityIndicatorRenderer(Context context) : base(context)
//    //    {
//    //    }

//    //    protected override void OnElementChanged(ElementChangedEventArgs<BlockingActivityIndicator> e)
//    //    {
//    //        base.OnElementChanged(e);

//    //        //if (e.NewElement != null)
//    //        //{
//    //        //    // Create a transparent overlay to block user interaction
//    //        //    var overlay = new FrameLayout(Context);
//    //        //    overlay.SetBackgroundColor(Android.Graphics.Color.Transparent);
//    //        //    overlay.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

//    //        //    // Add the activity indicator to the overlay
//    //        //    var activityIndicator = new Android.Widget.ProgressBar(Context);
//    //        //    activityIndicator.Indeterminate = true;
//    //        //    var layoutParams = new FrameLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent, GravityFlags.Center);
//    //        //    overlay.AddView(activityIndicator, layoutParams);

//    //        //    // Add the overlay to the renderer view
//    //        //    SetNativeControl(overlay);
//    //        //}
//    //    }
//    //}
//}
