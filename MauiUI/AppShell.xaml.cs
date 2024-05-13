using MauiUI.ViewModels;
using MauiUI.Views;
using System.ComponentModel;

namespace MauiUI
{
    public partial class AppShell : Shell
    {
        readonly AppShellViewModel _appShellViewModel;
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public AppShell(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BindingContext = _appShellViewModel = new AppShellViewModel(serviceProvider);
        }


        //void RegisterRoutes()
        //{
        //    Routes.Add(nameof(AdminPage), typeof(AdminPage));
        //    //Routes.Add(nameof(LocationPage), typeof(LocationPage));
        //    //Routes.Add(nameof(BarcodePage), typeof(BarcodePage));
        //    //Routes.Add(nameof(LoginPage), typeof(LoginPage));

        //    foreach (var item in Routes)
        //    {
        //        Routing.RegisterRoute(item.Key, item.Value);
        //    }
        //}
    }
}
