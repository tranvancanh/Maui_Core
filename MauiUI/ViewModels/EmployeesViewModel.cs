using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Models;
using System.Collections.ObjectModel;

namespace MauiUI.ViewModels
{
    
    public partial class EmployeesViewModel : BaseViewModel
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
    }
}
