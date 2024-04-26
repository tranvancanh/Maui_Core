using CommunityToolkit.Maui.Views;

namespace MauiUI.Services
{
    public interface ILoadingService
    {
        void Init(Page page);
        void ClosePopup(Popup popup);
        void ShowPopup(Popup popup);
    }

    public class LoadingService : ILoadingService
    {
        Page page { get; set; }

        public void ClosePopup(Popup popup)
        {
            if (page == null)
                page = Application.Current?.MainPage ?? throw new NullReferenceException();
            popup.Close();
        }

        public void Init(Page page)
        {
            this.page = page;
        }

        public void ShowPopup(Popup popup)
        {
            if (page == null)
                page = Application.Current?.MainPage ?? throw new NullReferenceException();
            page.ShowPopup(popup);
        }
    }
}
