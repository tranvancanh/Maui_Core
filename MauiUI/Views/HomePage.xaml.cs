using MauiUI.ViewModels;

namespace MauiUI.Views;

public partial class HomePage : ContentPage
{
    readonly HomePageViewModel _homePageViewModel;
    public HomePage(HomePageViewModel homePageViewModel)
	{
        InitializeComponent();
        _homePageViewModel = homePageViewModel;
        BindingContext = _homePageViewModel;
    }

   
}