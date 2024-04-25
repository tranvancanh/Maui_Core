using MauiUI.Views;
using System.Diagnostics;

namespace MauiUI.Services
{
    public interface INavigationService
    {
        Task NavigateToPage(Page page);
        Task PreviousPageBack();
        Task NavigateToSecondPage();
        Task NavigateToSettingPage();
    }

    public class NavigationService : INavigationService
    {
        readonly IServiceProvider _services;
        protected INavigation Navigation
        {
            get
            {
                INavigation? navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    //This is not good!
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    throw new Exception();
                }
            }
        }
        public NavigationService(IServiceProvider services)
            => _services = services;

        public Task NavigateToPage(Page page)
        {
            if (page is not null)
                return Navigation.PushAsync(page, true);
            throw new InvalidOperationException($"Unable to resolve type Page");
        }

        public Task PreviousPageBack()
        {
            return Navigation.PopAsync();
        }

        public Task NavigateToSecondPage()
        {
            var page = _services.GetService<LoginPage>();
            if (page is not null)
                return Navigation.PopAsync();
            //return Navigation.PushAsync(page, true);
            throw new InvalidOperationException($"Unable to resolve type LoginPage");
        }

        public Task NavigateToSettingPage()
        {
            var page = _services.GetService<AppSettingPage>();
            if (page is not null)
                return Navigation.PushAsync(page, true);
            throw new InvalidOperationException($"Unable to resolve type AppSettingPage");
        }

       
    }
}
