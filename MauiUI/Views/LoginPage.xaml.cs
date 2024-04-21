using MauiUI.ViewModels;

namespace MauiUI.Views;

public partial class LoginPage : ContentPage
{
    //readonly LoginViewModel _loginViewModel;
    public LoginPage()
	{
		InitializeComponent();
        //_loginViewModel = loginViewModel;
        //BindingContext = _loginViewModel;
        BindingContext = new LoginViewModel();
        //BindingContext = Application.Current.Handler.MauiContext.Services.GetService<LoginViewModel>();
    }

    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    await Task.CompletedTask;
    //    //await _loginPage.LoadLoginPageAsync();
    //}
}