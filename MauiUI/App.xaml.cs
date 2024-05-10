using MauiUI.AppConfigure;
using MauiUI.Services;
using MauiUI.Views;
using Microsoft.Maui.Platform;
using System.Diagnostics;
using System.Windows.Input;

namespace MauiUI
{
    public partial class App : Application
    {
        public ICommand InitApp { get; set; }
        readonly ILocationService _locationService;

        public App(LoginPage loginPage)
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

            MainPage = new NavigationPage(loginPage);
            //MainPage = new NavigationPage(appSystemSetting);
            //MainPage = loginPage;
            //MainPage = appSystemSetting;
            //MainPage = new EmployeeListPage();
            _locationService = MauiProgram.Services.GetRequiredService<ILocationService>();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            Debug.WriteLine("App Calling OnStart");
            await InitializeDatabase();
            await InitializeLocationService();
        }

        private async Task InitializeDatabase()
        {
            try
            {
                // Set up your database
                var dbInit = new SqlLiteAccess<bool>();

                // Ensure that the database is created and/or migrated to the latest version
                await dbInit.InitDb();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during initialization
                Debug.WriteLine("Error initializing database: " + ex.Message);
                throw;
            }
        }

        private async Task InitializeLocationService()
        {
            // Get the service instance
            //serverService = _serviceProvider.GetService<AppSettingPage>();
            //var serverService = MauiApplication.Current.Services.GetRequiredService<ILocationService>();

            // Run server initialization logic only if it hasn't been initialized before
            if (!_locationService.IsListening)
            {
                await _locationService.StartListeningForegroundAsync();
            }

            // Check service instance
            var locationServiceCheck = MauiProgram.Services.GetRequiredService<ILocationService>();
            if (locationServiceCheck.IsListening)
            {
                Debug.WriteLine("Started listening listened successfully!!!");
            }

        }
    }
}
