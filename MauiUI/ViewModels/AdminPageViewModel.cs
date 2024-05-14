using CommunityToolkit.Mvvm.Input;
using MauiUI.Views;
using System.Diagnostics;

namespace MauiUI.ViewModels
{
    //[QueryProperty(nameof(EmployeeId), nameof(EmployeeId))]
    public partial class AdminPageViewModel : BaseViewModel
    {
        private readonly IServiceProvider _serviceProvider;

        public AdminPageViewModel()
        {
            _serviceProvider = MauiProgram.Services.GetService<IServiceProvider>();
            Debug.WriteLine($"AdminPageViewModel at {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
        }

        [RelayCommand]
        private async Task BackAdmin()
        {
            Debug.WriteLine($"Back Admin at {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
            Application.Current.MainPage = new AppShell(_serviceProvider);
            //Application.Current.MainPage = new NavigationPage(page);

            await Task.CompletedTask;
            return;
        }
    }
}
