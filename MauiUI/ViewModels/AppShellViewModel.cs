using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Models;
using Microsoft.Maui.Hosting;
using System.Collections.ObjectModel;
namespace MauiUI.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<MauiUI.Models.FlyoutItem> flyoutItems = new ObservableCollection<MauiUI.Models.FlyoutItem>();

        [ObservableProperty]
        private string flyoutIcon = Icons.People;

        public AppShellViewModel()
        {
            //flyoutItems = new ObservableCollection<Maui_App.Models.FlyoutItem1>()
            //    {
            //        new Maui_App.Models.FlyoutItem1() { Title1 = "123"},
            //        new Maui_App.Models.FlyoutItem1() { Title1 = "1234" }
            //    };
            var flyoutItem = new Models.FlyoutItem()
            {
                Title = "Dashboard Page",
                //Route = nameof(StudentDashboardPage),
                //FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                //Items =
                //            {
                //                new ShellContent
                //                {
                //                    Icon = Icons.Dashboard,
                //                    Title = "Student Dashboard",
                //                    ContentTemplate = new DataTemplate(typeof(StudentDashboardPage)),
                //                },
                //                new ShellContent
                //                {
                //                    Icon = Icons.AboutUs,
                //                    Title = "Student Profile",
                //                    ContentTemplate = new DataTemplate(typeof(StudentProfilePage)),
                //                },
                //            }
            };

            flyoutItems.Add(flyoutItem);

        }

        [RelayCommand]
        private async Task SignOut()
        {
            //if (Preferences.ContainsKey(nameof(App.UserDetails)))
            //{
            //    Preferences.Remove(nameof(App.UserDetails));
            //}
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        //[ObservableProperty]
        //private FlyoutItem flyoutItems = new();





    }


}
