namespace MauiUI.Controls
{
    public class CustomEntry_old : Entry
    {
        public CustomEntry_old()
        {
            try
            {
                // get the style of a Label in an unsafe way
                //var labelStyle = Application.Current!.GetStyle<Entry>();

                //var style = Resources["PrimaryTextColor"];
                //var targetResource1 = Microsoft.Maui.Controls.Application.Current.Resources;
                //ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);

                this.FontFamily = "Rounded Mplus 1c";
                this.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                //this.TextColor = (Color)targetResource["PrimaryTextColor"];
                this.Keyboard = Keyboard.Text;
                this.Focused += OnFocus;
                this.Unfocused += OnFocusOut;
            }
            catch (Exception ex)
            {

            }
           
        }

        void OnFocus(object sender, FocusEventArgs args)
        {
            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);

            this.BackgroundColor = (Color)targetResource["ActiveEntryBackColor"];
        }

        void OnFocusOut(object sender, FocusEventArgs args)
        {
            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);

            this.BackgroundColor = (Color)targetResource["TransparentColor"];
        }

    }
    public class CustomPicker : Picker
    {
        public CustomPicker()
        {
            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);

            this.FontFamily = "Rounded Mplus 1c";
            this.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            this.TextColor = (Color)targetResource["PrimaryTextColor"];
        }
    }
    public class CustomDatePicker : DatePicker
    {
        public CustomDatePicker()
        {
            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);

            this.FontFamily = "Rounded Mplus 1c";
            this.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            this.TextColor = (Color)targetResource["PrimaryTextColor"];
        }
    }
}
