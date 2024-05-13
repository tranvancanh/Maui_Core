using CommunityToolkit.Maui;
using MauiUI.Controls;
using MauiUI.Services;
using MauiUI.ViewModels;
using MauiUI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;
using System.Reflection;

namespace MauiUI
{
    public static class MauiProgram
    {
        public static IServiceProvider Services { get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesome6Regular");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesome6Solid");
                    fonts.AddFont("MPLUSRounded1c-Regular.ttf", "Rounded Mplus 1c");
                    fonts.AddFont("MPLUSRounded1c-Bold.ttf", "Rounded Mplus 1c Bold");
                    fonts.AddFont("ZenKurenaido-Regular.ttf", "ZenKurenaidoRegular");
                    fonts.AddFont("KiwiMaru-Regular.ttf", "KiwiMaruRegular");
                });
            builder.AddAppSettings();


            // Add Views
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<AppSettingPage>();
            builder.Services.AddTransient<LoadingPopup>();
            builder.Services.AddTransient<ExamplePage1>();
            builder.Services.AddTransient<ExamplePage2>();
            builder.Services.AddTransient<ExamplePage3>();

            // Add View Models
            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<AppShellViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<AppSettingViewModel>();
            builder.Services.AddTransient<ExamplePage1ViewModel>();
            builder.Services.AddTransient<ExamplePage2ViewModel>();
            builder.Services.AddTransient<ExamplePage3ViewModel>();

            // Add Services
            builder.Services.AddSingleton<MauiUI.Services.IAuthService, MauiUI.Services.AuthService>();
            builder.Services.AddSingleton<MauiUI.Services.IDataService, MauiUI.Services.DataService>();
            builder.Services.AddSingleton<MauiUI.Services.IAppSettingService, AppSettingService>();
            builder.Services.AddTransient<MauiUI.Services.ICallApiService, MauiUI.Services.CallApiService>();
            builder.Services.AddSingleton<MauiUI.Services.INavigationService, MauiUI.Services.NavigationService>();
            builder.Services.AddTransient<MauiUI.Services.ILoadingService, MauiUI.Services.LoadingService>();
            builder.Services.AddSingleton<MauiUI.Services.ILocationService, LocationService>();

            //#if DEBUG
            //    builder.Logging.AddDebug();
            //#endif

            builder.ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                                events.AddAndroid(android => android
                                    .OnActivityResult((activity, requestCode, resultCode, data) => LogEvent(nameof(AndroidLifecycle.OnActivityResult), requestCode.ToString()))
                                    .OnStart((activity) => LogEvent(nameof(AndroidLifecycle.OnStart)))
                                    .OnCreate((activity, bundle) => LogEvent(nameof(AndroidLifecycle.OnCreate)))
                                    .OnBackPressed((activity) => LogEvent(nameof(AndroidLifecycle.OnBackPressed)) && false)
                                    .OnStop((activity) => LogEvent(nameof(AndroidLifecycle.OnStop))));

#elif IOS
                                events.AddiOS(ios => ios
                                       .OnActivated((app) => LogEvent(nameof(iOSLifecycle.OnActivated)))
                                       .OnResignActivation((app) => LogEvent(nameof(iOSLifecycle.OnResignActivation)))
                                       .DidEnterBackground((app) => LogEvent(nameof(iOSLifecycle.DidEnterBackground)))
                                       .WillTerminate((app) => LogEvent(nameof(iOSLifecycle.WillTerminate))));

#elif WINDOWS

                events.AddWindows(windows => windows
                           .OnActivated((window, args) => LogEvent(nameof(WindowsLifecycle.OnActivated)))
                           .OnClosed((window, args) => LogEvent(nameof(WindowsLifecycle.OnClosed)))
                           .OnLaunched((window, args) => LogEvent(nameof(WindowsLifecycle.OnLaunched)))
                           .OnLaunching((window, args) => LogEvent(nameof(WindowsLifecycle.OnLaunching)))
                           .OnVisibilityChanged((window, args) => LogEvent(nameof(WindowsLifecycle.OnVisibilityChanged)))
                           .OnPlatformMessage((window, args) =>
                           {
                               if (args.MessageId == Convert.ToUInt32("031A", 16))
                               {
                                   // System theme has changed
                               }
                           }));
#endif

            });

            //CustomEntry entry
            Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
            {
                if (view is CustomEntry)
                {
#if __ANDROID__
                    MauiUI.Platforms.Android.Renderers.CustomEntryMapper.Map(handler, view);
//#elif __IOS__
//                    MauiUI.Platform.iOS.Renderers.CustomEntryMapper.Map(handler, view);
#endif
                }
            });

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

            var app = builder.Build();

            Services = app.Services;

            return app;
        }

        private static void AddAppSettings(this MauiAppBuilder mauiAppBuilder)
        {
            var environment = string.Empty;
#if DEBUG
            // Do something specific for debug mode
            environment = "Development";
#elif RELEASE
            // Do something specific for release mode
            environment = "Production";
#else
            throw new Exception("Environment is not support");
#endif

            // add appsetting file
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"MauiUI.appsettings.{environment}.json"))
            {
                if (stream != null)
                {
                    var config = new ConfigurationBuilder()
                  .AddJsonStream(stream)
                  .Build();
                    mauiAppBuilder.Configuration.AddConfiguration(config);
                    
                }
            }

        }

        //public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        //{
        //    mauiAppBuilder.Services.AddTransient<IAuthService, AuthService>();
        //    mauiAppBuilder.Services.AddTransient<IDataService, DataService>();

        //    // More services registered here.

        //    return mauiAppBuilder;
        //}

        //public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        //{
        //    mauiAppBuilder.Services.AddSingleton<HomePageViewModel>();
        //    mauiAppBuilder.Services.AddSingleton<LoginViewModel>();

        //    // More view-models registered here.

        //    return mauiAppBuilder;
        //}

        //public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        //{
        //    mauiAppBuilder.Services.AddSingleton<HomePage>();
        //    mauiAppBuilder.Services.AddSingleton<LoginPage>();

        //    // More views registered here.

        //    return mauiAppBuilder;
        //}

        private static bool LogEvent(string eventName, string type = null)
        {
            System.Diagnostics.Debug.WriteLine($"App is : {eventName}{(type == null ? string.Empty : $" ({type})")}");
            return true;
        }
    }
}
