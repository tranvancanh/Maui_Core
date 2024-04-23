using CommunityToolkit.Maui;
using MauiUI.Controls;
using MauiUI.Services;
using MauiUI.ViewModels;
using MauiUI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.LifecycleEvents;
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

                    //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    //fonts.AddFont("MPLUSRounded1c-Regular.ttf", "Rounded Mplus 1c");
                    //fonts.AddFont("MPLUSRounded1c-Bold.ttf", "Rounded Mplus 1c Bold");
                    //fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesome6Regular");
                    //fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesome6Solid");
                    //fonts.AddFont("ZenKurenaido-Regular.ttf", "ZenKurenaidoRegular");
                    //fonts.AddFont("KiwiMaru-Regular.ttf", "KiwiMaruRegular");

                    //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                //                                .ConfigureMauiHandlers((handlers) =>
                //                                {
                //#if ANDROID
                //                                    handlers.AddHandler(typeof(MauiUI.Controls.CustomEntry_old), typeof(MauiUI.Platforms.Android.Renderers.CustomEntryMapper));
                //#elif IOS
                //                                //handlers.AddHandler(typeof(PressableView), typeof(XamarinCustomRenderer.iOS.Renderers.PressableViewRenderer));
                //#endif
                //                                })

                ;


            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IDataService, DataService>();
            builder.Services.AddSingleton<IAppSettingService, AppSettingService>();

            // Add Views
            //builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<AppSettingPage>();
            builder.Services.AddTransient<EmployeeListPage>();
            builder.Services.AddTransient<LoadingPopup>();

            // Add View Models
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<AppSettingViewModel>();
            builder.Services.AddTransient<EmployeesViewModel>();

            // Add Services
            builder.Services.AddSingleton<MauiUI.Services.INavigationService, MauiUI.Services.NavigationService>();
            builder.Services.AddTransient<MauiUI.Services.IPopupService, MauiUI.Services.PopupService>();

            // add appsetting file
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("1.MauiUI.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            builder.Configuration.AddConfiguration(config);

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

            Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
            {
                if (view is CustomEntry)
                {
                    MauiUI.Platforms.Android.Renderers.CustomEntryMapper.Map(handler, view);
                }
            });

            var app = builder.Build();

            Services = app.Services;

            return app;
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
