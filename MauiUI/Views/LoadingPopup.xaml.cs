using CommunityToolkit.Maui.Views;

namespace MauiUI.Views;

public partial class LoadingPopup : Popup
{
	public LoadingPopup()
	{
		InitializeComponent();
	}

    public LoadingPopup(string displayText)
    {
        InitializeComponent();
        DisplayText.Text = displayText;
    }
}