using MauiUI.ViewModels;

namespace MauiUI.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
        InitializeComponent();
        BindingContext = new HomePageViewModel();
    }

   
}