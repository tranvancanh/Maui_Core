using MauiUI.ViewModels;
using MauiUI.Views;
using Microsoft.Maui.Platform;
using System.Windows.Input;

namespace MauiUI
{
    public partial class App : Application
    {
        public ICommand InitApp { get; set; }

        public App(AppSettingPage appSystemSetting)
        {
            InitializeComponent();

            //Border less entry
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Blue.ToPlatform());
#elif __IOS__
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
                }
            });

            //InitApp = new Command(async () => await NewInitApp());

            MainPage = appSystemSetting;
            //MainPage = new NavigationPage(appSystemSetting);
            //MainPage = new EmployeeListPage();

        }

        private async Task NewInitApp()
        {
            await Task.CompletedTask;
            //await Shell.Current.GoToAsync(nameof(NewNavigationPage));
            return;
        }
    }
}
