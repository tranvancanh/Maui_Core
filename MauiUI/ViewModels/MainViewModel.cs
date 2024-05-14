using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiUI.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(LabelText))]
        private int count;

        //[ObservableProperty]
        //private string labelText;

        public string LabelText => $"Count to {Count}";


        [RelayCommand]
        private void CountUp()
        {
            Count++;
        }

        [RelayCommand]
        private async Task GotoEmployeeListPage()
        {
            //await Shell.Current.GoToAsync($"{ nameof(HomePage)}?EmployeeId={Count}");
            await Task.CompletedTask;
        }


        //public int Count
        //{
        //    get => count;
        //    set
        //    {
        //        _count = value;
        //    }
        //}

        //private string _clickText = "Click me";
        //public string ClickText
        //{
        //    get
        //    {
        //        if(_count == 1)
        //            ClickText = $"Clicked {_count} time";
        //        else
        //            ClickText = $"Clicked {_count} times";
        //        return ClickText;
        //    }
        //    set => SetProperty(ref _clickText, value);
        //}

        //[RelayCommand]
        //private void CountUp()
        //{
        //    _count++;
        //    Count = _count;
        //}
    }
}
