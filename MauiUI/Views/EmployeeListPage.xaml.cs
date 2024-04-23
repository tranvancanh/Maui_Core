using CommunityToolkit.Maui.Views;
using MauiUI.ViewModels;

namespace MauiUI.Views;

public partial class EmployeeListPage : ContentPage
{
    private readonly EmployeesViewModel _employeesViewModel;
    public EmployeeListPage(EmployeesViewModel employeesViewModel)
    {
        InitializeComponent();
        _employeesViewModel = employeesViewModel;
        BindingContext = _employeesViewModel;
        //BindingContext = new EmployeesViewModel();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var popup = new LoadingPopup();
        try
        {
            this.ShowPopup(popup);
            Thread.Sleep(10000);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            popup.Close();
        }
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {

    }
}