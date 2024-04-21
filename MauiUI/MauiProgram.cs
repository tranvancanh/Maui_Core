using CommunityToolkit.Maui;
using MauiUI.Services;
using MauiUI.ViewModels;
using MauiUI.Views;
using Microsoft.Maui.LifecycleEvents;

namespace MauiUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                //.UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    //fonts.AddFont("MPLUSRounded1c-Regular.ttf", "Rounded Mplus 1c");
                    //fonts.AddFont("MPLUSRounded1c-Bold.ttf", "Rounded Mplus 1c Bold");
                    //fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesome6Regular");
                    //fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesome6Solid");
                    //fonts.AddFont("ZenKurenaido-Regular.ttf", "ZenKurenaidoRegular");
                    //fonts.AddFont("KiwiMaru-Regular.ttf", "KiwiMaruRegular");
                    
                    //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IDataService, DataService>();
            builder.Services.AddSingleton<IAppSettingService, AppSettingService>();

            // Add Services DI, Views , View Models
            //builder.Services.AddTransient<MainPage>();
            //builder.Services.AddTransient<MainViewModel>();
            //builder.Services.AddTransient<HomePage>();
            //builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<AppSettingPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<AppSettingViewModel>();





            //Views
            //builder.Services.AddTransient<HomePage>();
            //builder.Services.AddTransient<LoginPage>();
            //builder.Services.AddTransient<DashboardPage>();
            //builder.Services.AddTransient<LoadingPage>();
            //builder.Services.AddTransient<StudentDashboardPage>();
            //builder.Services.AddTransient<StudentProfilePage>();


            //View Models
            //builder.Services.AddTransient<HomePageViewModel>();
            //builder.Services.AddTransient<LoginPageViewModel>();
            //builder.Services.AddTransient<DashboardPageViewModel>();
            //builder.Services.AddTransient<LoadingPageViewModel>();
            //builder.Services.AddTransient<StudentDashboardViewModel>();


            //#if DEBUG
            //    		builder.Logging.AddDebug();
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

            return builder.Build();
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
