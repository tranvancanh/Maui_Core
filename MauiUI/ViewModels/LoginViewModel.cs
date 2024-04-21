using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Models;
using MauiUI.Services;
using System.Collections.ObjectModel;

namespace MauiUI.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {

        [ObservableProperty]
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        [ObservableProperty]
        private Employee employee = new();

        [ObservableProperty]
        private string txtuser;

        [RelayCommand]
        private async Task Add()
        {
            await Task.Delay(1000);
            Employees.Add(Employee);
            Employee = new Employee();
        }


        [ObservableProperty]
        public bool contentIsVisible;

        [ObservableProperty]
        private string appVersion;

        [ObservableProperty]
        private ImageSource loginIconImageSource;

        //[ObservableProperty]
        //private string txtuser;

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

        //public Command LoginCommand { get; }
        //public Command SetUpCommand { get; }

        private readonly IAuthService _authService;

        //public LoginViewModel()
        //{
        //    //_authService = authService;
        //    LoginCommand = new Command(async () => await OnLoginClickAsync());
        //    SetUpCommand = new Command(async () => await OnSetUpClickAsync());
        //}

        //public LoginViewModel(IAuthService authService)
        //{
        //    _authService = authService;
        //    LoginCommand = new Command(async () => await OnLoginClickAsync());
        //    SetUpCommand = new Command(async () => await OnSetUpClickAsync());
        //}

        [RelayCommand]
        private async Task Login()
        {
            await _authService.IsAuthenticateAsync();
            return;
        }

        [RelayCommand]
        private async Task SetUp()
        {
             await Task.CompletedTask;
            return;
        }

        private async Task OnLoginClickAsync()
        {
            await _authService.IsAuthenticateAsync();
            return;
        }

        private Task OnSetUpClickAsync()
        {
            return Task.CompletedTask;
        }

        public Task LoadLoginPageAsync()
        {
            return Task.CompletedTask;
        }


    }
}
