using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Models;
using MauiUI.Services;
using MauiUI.Views;
using System.Diagnostics;
namespace MauiUI.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string flyoutIcon = Icons.People;

        [ObservableProperty]
        private bool isAdmin;

        [ObservableProperty]
        private string signOutText;

        [ObservableProperty]
        private string loginDataViewText;

        [ObservableProperty]
        private string dropText;

        [ObservableProperty]
        private bool userDialogIsVisible;

        [ObservableProperty]
        private string companyCodeText;

        [ObservableProperty]
        private string companyCode;

        [ObservableProperty]
        private string companyNameText;

        [ObservableProperty]
        private string companyName;

        [ObservableProperty]
        private string depoCodeText;

        [ObservableProperty]
        private int depoCode;

        [ObservableProperty]
        private string depoNameText;

        [ObservableProperty]
        private string depoName;

        [ObservableProperty]
        private string userCodeText;

        [ObservableProperty]
        private string userCode;

        [ObservableProperty]
        private string userNameText;

        [ObservableProperty]
        private string userName;

        private readonly IServiceProvider _serviceProvider;
        private readonly INavigationService _navigationService;

        public AppShellViewModel(IServiceProvider serviceProvider)
        {
            LoginDataViewText = "ログイン情報";
            SignOutText = "\uf2f5 ログアウト";
            CompanyCodeText = "会社コード";
            CompanyCode = "1";
            CompanyNameText = "会社名";
            CompanyName = "東山テスト";
            DepoCodeText = "デポコード";
            DepoCode = 10;
            DepoNameText = "デポ名称";
            DepoName = "名和デポ";
            UserCodeText = "ユーザーコード";
            UserCode = "1012";
            UserNameText = "ユーザー名";
            UserName = "田中";
            DropText = "\uf078";
            UserDialogIsVisible = false;
            IsAdmin = true;

            _serviceProvider = serviceProvider;

        }

        [RelayCommand]
        private async Task LoginDataViewClicked()
        {
            var getDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fffff");
            Debug.WriteLine($"Click Infor User, At Date Time : {getDateTime}");
            UserDialogIsVisible = !UserDialogIsVisible;
            if (UserDialogIsVisible)
                DropText = "\uf106";
            else
                DropText = "\uf078";
            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task SignOut()
        {
            //var loginPage = new LoginPage(new LoginViewModel(_authService, _navigationService, _callApiService, _serviceProvider));
            var page = _serviceProvider.GetService<LoginPage>();
            Application.Current.MainPage = new NavigationPage(page);
            await Task.CompletedTask;
        }

    }


}
