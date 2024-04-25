using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Services;
using MauiUI.Views;
using System.Diagnostics;

namespace MauiUI.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {

        [ObservableProperty]
        private string txtuser;

        [ObservableProperty]
        public bool contentIsVisible;

        [ObservableProperty]
        private string appVersion;

        [ObservableProperty]
        private ImageSource loginIconImageSource;

        [ObservableProperty]
        private string txtpass;

        [ObservableProperty]
        private bool isPass = true;

        [ObservableProperty]
        private bool notSetting = true;

        [ObservableProperty]
        ImageSource settingIcon = "";

        [ObservableProperty]
        private bool zxingIsVisible = false;

        [ObservableProperty]
        private string scanMessage;

        [ObservableProperty]
        private bool frameVisible;

        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;
        private readonly IAppSettingService _appSettingService;
        private readonly ICallApiService _callApiService;
        private readonly IServiceProvider _services;

        public LoginViewModel(IAuthService authService,
          INavigationService navigationService,
          ICallApiService callApiService,
          IServiceProvider services)
        {
            _callApiService = callApiService;
            _authService = authService;
            _navigationService = navigationService;
            _services = services;
        }

        public async Task LoadLoginPageAsync()
        {
            AppVersion = GetAppVersion();
            await Task.CompletedTask;
            return;
        }

        [RelayCommand]
        private async Task Login()
        {
            await _authService.IsAuthenticateAsync();
            return;
        }

        [RelayCommand]
        private async Task SetUp()
        {
            var page = _services.GetService<AppSettingPage>();
            await _navigationService.NavigateToPage(page);
            return;
        }

        private string GetAppVersion()
        {
            // appVersion and appBuild 
            var appVersion = AppInfo.VersionString;
            var appBuild = AppInfo.BuildString;
            Debug.WriteLine($"Version: {appVersion}, Build: {appBuild}");

            return appVersion;
        }
    }
}
