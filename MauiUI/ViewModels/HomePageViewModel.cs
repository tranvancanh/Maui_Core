using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Models;
using MauiUI.Services;
using MauiUI.Views;
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


        private readonly INavigationService _navigationService;
        private readonly IServiceProvider _serviceProvider;

        public HomePageViewModel(INavigationService navigationService,
          IServiceProvider serviceProvider)
        {
            UserName = "東山テスト";
            _navigationService  = navigationService;
            _serviceProvider = serviceProvider;
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

                var pageId = menuClicked.HandyPageID;
                switch (pageId)
                {
                    case 1:
                        {
                            var page = _serviceProvider.GetService<ExamplePage1>();
                            await _navigationService.NavigateToPage(page);
                            break;
                        }
                    case 2:
                        {
                            var page = _serviceProvider.GetService<ExamplePage2>();
                            await _navigationService.NavigateToPage(page);
                            break;
                        }
                    case 3:
                        {
                            var page = _serviceProvider.GetService<ExamplePage3>();
                            await _navigationService.NavigateToPage(page);
                            break;
                        }
                }

                // DoSomething
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                SelectedItems = new MenuX();
            }
        }
    }
}
