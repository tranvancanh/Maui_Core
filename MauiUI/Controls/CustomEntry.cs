namespace MauiUI.Controls
{
    public class CustomEntry : Entry
    {
        public CustomEntry()
        {
            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);

            this.FontFamily = "Rounded Mplus 1c";
            this.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            this.TextColor = (Color)targetResource["PrimaryTextColor"];
            this.Keyboard = Keyboard.Text;
            this.Focused += OnFocus;
            this.Unfocused += OnFocusOut;
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
