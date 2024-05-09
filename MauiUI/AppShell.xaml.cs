using MauiUI.ViewModels;

namespace MauiUI
{
    public partial class AppShell : Shell
    {
        readonly AppShellViewModel _appShellViewModel;
        public AppShell(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BindingContext = _appShellViewModel = new AppShellViewModel(serviceProvider);
        }
    }
}
