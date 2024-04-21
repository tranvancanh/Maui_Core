using MauiUI.ViewModels;

namespace MauiUI.Views;

public partial class EmployeeListPage : ContentPage
{
    public EmployeeListPage()
    {
        InitializeComponent();

        BindingContext = new EmployeesViewModel();

    }
}