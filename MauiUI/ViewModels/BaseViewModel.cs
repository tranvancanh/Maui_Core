using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiUI.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string title;


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        [ObservableProperty]
        private bool backgroundLayerIsVisible = false;

        [ObservableProperty]
        private bool dialogIsVisible = false;

        [ObservableProperty]
        string dialogTitleText = string.Empty;

        [ObservableProperty]
        string dialogMainText = string.Empty;

        [ObservableProperty]
        string dialogSubText = string.Empty;

        [ObservableProperty]
        private bool dialogSubTextIsVisible = false;

        [ObservableProperty]
        private bool contentIsVisible = false;

        [ObservableProperty]
        private bool activityRunning = false;

        [ObservableProperty]
        private string activityRunningText;

        [ObservableProperty]
        private Color activityRunningColor;

        [ObservableProperty]
        private bool confirmDialogIsVisible = false;
        

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

       

        public bool ActivityRunningLoading()
        {
            ContentIsVisible = false;
            ActivityRunningText = "Loanding....";
            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);
            ActivityRunningColor = (Color)targetResource["MainColor"];
            ActivityRunning = true;
            return true;
        }

        public bool ActivityRunningProcessing()
        {
            ContentIsVisible = false;
            ActivityRunningText = "Processing.....";
            ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);
            ActivityRunningColor = (Color)targetResource["AccentTextColor"];
            ActivityRunning = true;
            return true;
        }

        public bool ActivityRunningEnd()
        {
            ActivityRunning = false;
            ContentIsVisible = true;
            return true;
        }
    }
}
