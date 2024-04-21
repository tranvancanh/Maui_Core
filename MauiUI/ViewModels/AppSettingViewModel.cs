using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiUI.Services;
using System.Collections.ObjectModel;

namespace MauiUI.ViewModels
{
    public partial class AppSettingViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string urlConnect;
        [ObservableProperty]
        private string companyCode;
        [ObservableProperty]
        private string companyPassword;
        [ObservableProperty]
        private string loginId;
        [ObservableProperty]
        private string selectedScanMode;
        [ObservableProperty]
        private string selectedScanOkSound;
        [ObservableProperty]
        private string selectedScanErrorSound;

        [ObservableProperty]
        private ObservableCollection<List<string>> scanModes = new ObservableCollection<List<string>>();

        [ObservableProperty]
        private ObservableCollection<List<string>> scanOkSounds = new ObservableCollection<List<string>>();

        [ObservableProperty]
        private ObservableCollection<List<string>> scanErrorSounds = new ObservableCollection<List<string>>();

        [ObservableProperty]
        private string companyName;

        [ObservableProperty]
        private string useDeviceID;


        [ObservableProperty]
        private string pageTitle;

        private readonly IAuthService _authService;
        private readonly IAppSettingService _appSettingService;

        public AppSettingViewModel(IAuthService authService, IAppSettingService appSettingService) 
        {
            _authService = authService;
            _appSettingService = appSettingService;
            PageTitle = "アプリ設定";
            //CompanyName = App.Company.CompanyName;
        }

        [RelayCommand]
        private async void GetLastedMaster()
        {

            //try
            //{
            //    //// グルグル開始
            //    //ActivityIndicatorText = "最新マスター取得中";
            //    //IsLoadingStart();

            //    //await Utils.GetLatestMasterData();

            //    //// グルグル終了
            //    //IsLoadingEnd();
            //    return;
            //}
            //catch (CustomExtention ex)
            //{
            //    if (ex is CustomExtention) await DisplayAlertError(ex.Message);
            //    else await DisplayAlertError();
            //    return;
            //}

            await Task.CompletedTask;
        }

        [RelayCommand]
        private async void LogoutCompany()
        {
            //var result = await Application.Current.MainPage
            //    .ShowPopupAsync(new DisplayDialogPage("会社ログアウトを行います。よろしいですか？"));

            //// 会社ログアウト(利用デバイス解除)を実行
            //if (result != null)
            //{
            //    try
            //    {
            //        // グルグル開始
            //        IsLoadingStart();

            //        // 未送信作業記録の存在確認
            //        var taskRecords = await App.TableRepository.GetTaskRecordList();
            //        var taskRecordsNotSendingCount = taskRecords.Where(x => x.IsComplete == false).ToList().Count;
            //        // 未送信作業中断記録の存在確認
            //        var taskInterruptRecords = await App.TableRepository.GetTaskInterruptRecordList();
            //        var taskInterruptRecordsNotSendingCount = taskInterruptRecords.Where(x => x.IsComplete == false).ToList().Count;

            //        if (taskRecordsNotSendingCount > 0 || taskInterruptRecordsNotSendingCount > 0)
            //        {
            //            // 未送信データが存在する場合はログアウト不可
            //            await DisplayAlertError("未送信データが存在するため会社ログアウトできません。");
            //            return;
            //        }

            //        // DBの利用デバイス解除更新
            //        var requestCancelUseDeviceStatus = new RequestCancelUseDeviceStatus();
            //        var useDeviceStatus = await App.TableRepository.GetUseDeviceStatus();
            //        requestCancelUseDeviceStatus.UseDeviceStatusId = useDeviceStatus.UseDeviceStatusId;
            //        await APIClass.PostCancelUseDeviceStatus(requestCancelUseDeviceStatus);

            //        // SQLiteの会社情報を削除
            //        await App.TableRepository.DeleteCompany();
            //        // SQLiteの利用デバイス情報を削除
            //        await App.TableRepository.DeleteUseDeviceStatus();
            //        // SQLiteのマスターを全て削除
            //        await App.TableRepository.DeleteMaster();

            //        // 会社ログインページに戻る
            //        Application.Current.MainPage = new NavigationPage(new LoginTaskUserPage());
            //    }
            //    catch (CustomExtention ex)
            //    {
            //        if (ex is CustomExtention) await DisplayAlertError(ex.Message);
            //        else await DisplayAlertError();
            //        return;
            //    }
            //}
            //else
            //{
            //    // グルグル終了
            //    IsLoadingEnd();
            //    return;
            //}

            await Task.CompletedTask;
        }

    }
}
