using MauiUI.AppConfigure;
using MauiUI.Views;
using Microsoft.Maui.Platform;
using System.Diagnostics;
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
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
                }
            });

            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);

            //InitApp = new Command(async () => await NewInitApp());

            MainPage = new NavigationPage(appSystemSetting);
            //MainPage = appSystemSetting;
            //MainPage = new EmployeeListPage();

        }

        protected override async void OnStart()
        {
            await InitializeDatabase();
        }

        private async Task InitializeDatabase()
        {
            try
            {
                // Set up your database context
                var dbContext = new SqlLiteAccess<bool>();

                // Ensure that the database is created and/or migrated to the latest version
                await dbContext.InitDb();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during initialization
                Debug.WriteLine("Error initializing database: " + ex.Message);
                throw;
            }
        }
    }
}
