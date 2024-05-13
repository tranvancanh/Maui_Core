using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MauiUI.ViewModels
{
    //[QueryProperty(nameof(EmployeeId), nameof(EmployeeId))]
    public partial class AdminPageViewModel : BaseViewModel
    {


        [RelayCommand]
        private async Task BackAdmin123()
        {
            Debug.WriteLine($"back Admin at {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
            await Shell.Current.GoToAsync("..");
            return;
        }
    }
}
