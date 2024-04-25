using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.AppConfigure;
using MauiUI.Models;
using MauiUI.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiUI.ViewModels
{
    public partial class AppSettingViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string urlConnect;
        [ObservableProperty]
        private int companyId;
        [ObservableProperty]
        private string companyCode;
        [ObservableProperty]
        private string companyPassword;
        [ObservableProperty]
        private int handyUserId;
        [ObservableProperty]
        private string handyUserCode;
        [ObservableProperty]
        private string selectedScanMode;
        [ObservableProperty]
        private string selectedScanOkSound;
        [ObservableProperty]
        private string selectedScanErrorSound;

        [ObservableProperty]
        private ObservableCollection<List<string>> scanModes = new ObservableCollection<List<string>>();

        [ObservableProperty]
        private ObservableCollection<List<string>> scanOkSounds = new ObservableCollection<List<string>>();

        [ObservableProperty]
        private ObservableCollection<List<string>> scanErrorSounds = new ObservableCollection<List<string>>();

        [ObservableProperty]
        private string companyName;

        [ObservableProperty]
        private string useDeviceID;


        [ObservableProperty]
        private string pageTitle;

        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;
        private readonly IAppSettingService _appSettingService;
        private readonly ICallApiService _callApiService;

        public AppSettingViewModel(IAuthService authService, 
            IAppSettingService appSettingService, 
            INavigationService navigationService,
            ICallApiService callApiService) 
        {
            _callApiService = callApiService;
            _authService = authService;
            _appSettingService = appSettingService;
            _navigationService = navigationService;
            PageTitle = "アプリ設定";
        }

        [RelayCommand]
        private async Task Appearing()
        {
            try
            {
                // DoSomething
                var settingTable = (await SqlLiteAccess<SettingTable>.GetAsync()).FirstOrDefault();
                if (settingTable == null)
                {
                    var baseUrl = await _callApiService.BaseUrlWhenNotSetting();
                    UrlConnect = baseUrl;
                }
                else
                {
                    UrlConnect = settingTable.HandyApiUrl;
                    CompanyCode = settingTable.CompanyCode;
                    CompanyName = settingTable.CompanyName;
                    CompanyPassword = settingTable.CompanyPassword;
                    HandyUserCode = settingTable.HandyUserCode;
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        [RelayCommand]
        private async Task Disappearing()
        {
            try
            {

                // DoSomething
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        [RelayCommand]
        private async Task Back()
        {
            await _navigationService.BackPreviousPage();
            //Navigation.PushAsync(new NavigationPage(new EmployeeListPage()), true);
        }

        [RelayCommand]
        private async Task Register()
        {
            try
            {
                var content = await _callApiService.GetAsync("Test");
                //Navigation.PushAsync(new NavigationPage(new EmployeeListPage()), true);
                //await _navigationService.NavigateToSecondPage();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Message : " + ex.Message);
                throw;
            }
        }

    }
}
