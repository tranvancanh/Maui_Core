using MauiUI.ViewModels;

namespace MauiUI.Views;

public partial class LoginPage : ContentPage
{
    readonly LoginViewModel _loginViewModel;
    public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
        _loginViewModel = loginViewModel;
        BindingContext = _loginViewModel;
        //BindingContext = new LoginViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.CompletedTask;
        await _loginViewModel.LoadLoginPageAsync();
    }
}