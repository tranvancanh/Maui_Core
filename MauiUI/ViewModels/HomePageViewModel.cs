using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiUI.ViewModels
{
    [QueryProperty(nameof(EmployeeId), nameof(EmployeeId))]
    public partial class HomePageViewModel : BaseViewModel
    {

        [ObservableProperty]
        private int employeeId;


    }
}
