using Android.Content;
using MauiUI.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.AppCompat;
using Microsoft.Maui.Controls.Platform;
using static MauiUI.Platforms.Android.Renderers.CustomRenderer;


[assembly: ExportRenderer(typeof(CustomEntry_old), typeof(CustomEntryRenderer))]
[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace MauiUI.Platforms.Android.Renderers
{
    public class CustomRenderer
    {
        public class CustomEntryRenderer : EntryRenderer
        {
            public CustomEntryRenderer(Context context) : base(context) { }

            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);

                if (e.OldElement == null)
                {
                    Control.Background = null;
                    Control.SetPadding(5, 5, 5, 5);

                }
            }
        }

        public class CustomPickerRenderer : PickerRenderer
        {
            public CustomPickerRenderer(Context context) : base(context) { }

            protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged(e);

                if (e.OldElement == null)
                {
                    Control.Background = null;
                    Control.SetPadding(5, 5, 5, 5);
                    //Control.Typeface = Android.Graphics.Typeface.CreateFromAsset(Forms.Context.Assets, "MPLUSRounded1c-Bold.ttf");
                }
            }
        }

        public class CustomDatePickerRenderer : DatePickerRenderer
        {
            public CustomDatePickerRenderer(Context context) : base(context) { }

            protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
            {
                base.OnElementChanged(e);

                if (e.OldElement == null)
                {
                    Control.Background = null;
                    Control.SetPadding(5, 5, 5, 5);
                }
            }
        }
    }
}
