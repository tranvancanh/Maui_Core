using MauiUI.ViewModels;

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
    }
}
