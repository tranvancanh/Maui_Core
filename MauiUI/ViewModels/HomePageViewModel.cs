using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Models;
using System.Collections.ObjectModel;

namespace MauiUI.ViewModels
{
    //[QueryProperty(nameof(EmployeeId), nameof(EmployeeId))]
    public partial class HomePageViewModel : BaseViewModel
    {

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string depoName;

        [ObservableProperty]
        private ObservableCollection<MenuX> items = new ObservableCollection<MenuX>();

        [ObservableProperty]
        private MenuX selectedItems;


        public HomePageViewModel()
        {
            UserName = "東山テスト";
            items.Add(
                new MenuX()
                {
                    HandyPageID = 1,
                    HandyPageName = "Page 1",
                    HandyPageNumber = 1
                });
            items.Add(
                new MenuX()
                {
                    HandyPageID = 2,
                    HandyPageName = "Page 2",
                    HandyPageNumber = 2
                });
            items.Add(
                new MenuX()
                {
                    HandyPageID = 3,
                    HandyPageName = "Page 3",
                    HandyPageNumber = 3
                });
        }

        [RelayCommand]
        private async Task PageClicked(int handyPageID)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Menu {handyPageID} is Clicked");

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
        private async Task BtnSelectionChangedHeader()
        {
            try
            {

                var menuClicked = SelectedItems;

                System.Diagnostics.Debug.WriteLine($"Menu PageID {menuClicked.HandyPageID} is Clicked at {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");

                // DoSomething
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
