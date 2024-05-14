using MauiUI.ViewModels;

namespace MauiUI.Views;

public partial class AdminPage : ContentPage
{
    readonly AdminPageViewModel _adminPageViewModel;
    public AdminPage()
	{
		InitializeComponent();
        _adminPageViewModel = new AdminPageViewModel(); ;
        BindingContext = _adminPageViewModel;
    }
}