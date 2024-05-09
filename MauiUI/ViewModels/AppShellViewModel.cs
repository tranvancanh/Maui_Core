using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Models;
using MauiUI.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace MauiUI.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<MauiUI.Models.FlyoutItem> flyoutItems = new ObservableCollection<MauiUI.Models.FlyoutItem>();

        [ObservableProperty]
        private string flyoutIcon = Icons.People;

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

        public AppShellViewModel(IServiceProvider serviceProvider)
        {
            LoginDataViewText = "ログイン情報";
            SignOutText = "\uf2f5 ログアウト";
            CompanyCodeText = "会社コード";
            CompanyCode = "CompanyCode";
            CompanyNameText = "会社名";
            CompanyName = "CompanyName";
            DepoCodeText = "デポコード";
            DepoCode = 10;
            DepoNameText = "デポ名称";
            DepoName = "DepoName";
            UserCodeText = "ユーザーコード";
            UserCode = "UserCode";
            UserNameText = "ユーザー名";
            UserName = "UserName";
            DropText = "\uf078";
            UserDialogIsVisible = false;

            _serviceProvider = serviceProvider;
            //flyoutItems = new ObservableCollection<Maui_App.Models.FlyoutItem1>()
            //    {
            //        new Maui_App.Models.FlyoutItem1() { Title1 = "123"},
            //        new Maui_App.Models.FlyoutItem1() { Title1 = "1234" }
            //    };
            var flyoutItem = new Models.FlyoutItem()
            {
                Title = "Dashboard Page",
                //Route = nameof(StudentDashboardPage),
                //FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                //Items =
                //            {
                //                new ShellContent
                //                {
                //                    Icon = Icons.Dashboard,
                //                    Title = "Student Dashboard",
                //                    ContentTemplate = new DataTemplate(typeof(StudentDashboardPage)),
                //                },
                //                new ShellContent
                //                {
                //                    Icon = Icons.AboutUs,
                //                    Title = "Student Profile",
                //                    ContentTemplate = new DataTemplate(typeof(StudentProfilePage)),
                //                },
                //            }
            };

            flyoutItems.Add(flyoutItem);

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

            //Application.Current.MainPage = page;
            //await Shell.Current.GoToAsync($"{nameof(loginPage)}");
            //await _navigationService.NavigateToPage(page);
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            //MainPage = new NavigationPage();
            //Application.Current.MainPage = new LoginPage(new LoginViewModel(_authService, _navigationService, _callApiService, _serviceProvider));
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            await Task.CompletedTask;
        }

    }


}
