namespace MauiUI.Controls
{
    public sealed class CustomEntry : Entry
    {
        public CustomEntry()
        {
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

        void OnFocus(object sender, FocusEventArgs args)
        {
            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);
            ////this.BackgroundColor = (Color)targetResource["ActiveEntryBackColor"];
            //var color = (Color)targetResource["EntryFocusColor"];
            //this.BackgroundColor = color;
        }

        void OnFocusOut(object sender, FocusEventArgs args)
        {
            //ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);
            //var color = (Color)targetResource["EntryBackgroundColor"];
            //this.BackgroundColor = color;
        }


        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(CustomEntry), 0);

        public static BindableProperty BorderThicknessProperty =
            BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(CustomEntry), 0);

        public static BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(CustomEntry), new Thickness(5));

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomEntry), Colors.Transparent);

        public static BindableProperty CustomHeightProperty =
            BindableProperty.Create(nameof(CustomHeight), typeof(int), typeof(CustomEntry), 0);

        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set=> SetValue(BorderColorProperty, value);
        }
        /// <summary>
        /// This property cannot be changed at runtime in iOS.
        /// </summary>
        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        public int CustomHeight
        {
            get => (int)GetValue(CustomHeightProperty);
            set => SetValue(CustomHeightProperty, value);
        }
    }
}
