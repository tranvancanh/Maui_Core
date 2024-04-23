using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Models;
using MauiUI.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

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

        [ObservableProperty]
        private bool isEnabled = true;

        private readonly MauiUI.Services.IPopupService _popupService;
        private Page page;

        public EmployeesViewModel(MauiUI.Services.IPopupService popupService)
        {
            _popupService = popupService;
        }

        [RelayCommand]
        private async Task Add()
        {
            await Task.Delay(1000);
            Employees.Add(Employee);
            Employee = new Employee();
        }

        [RelayCommand]
        private async Task ClickBtn1()
        {
            var loading = new LoadingPopup();
            try
            {
                _popupService.ShowPopup(loading);
                await Task.Delay(10000);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _popupService.ClosePopup(loading);
            }


            //var popup = new SpinnerPopup();
            //try
            //{
            //    this.ShowPopup(popup);
            //    await Task.Delay(60000);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    popup.Close();
            //}

        }

        [RelayCommand]
        private async Task ClickBtn2()
        {
            try
            {
                IsBusy = true;
                IsEnabled = !IsBusy;
                await Task.Delay(10000);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                IsBusy = false;
                IsEnabled = !IsBusy;
            }
          
        }

        [RelayCommand]
        private async Task ActivityIndicatorLoad()
        {

        }

        [RelayCommand]
        private async Task ActivityIndicatorUnLoad()
        {

        }
    }
}
