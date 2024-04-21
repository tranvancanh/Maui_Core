using MauiUI.ViewModels;

namespace MauiUI.Views;

public partial class AppSettingPage : ContentPage
{
    private readonly AppSettingViewModel _appSystemSetting;
    public AppSettingPage(AppSettingViewModel appSystemSetting)
	{
		InitializeComponent();
        _appSystemSetting = appSystemSetting;
        BindingContext = _appSystemSetting;
	}

    /// <summary>
    /// デフォルト戻るボタンを無効化
    /// </summary>
    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    /// <summary>
    /// 戻るボタン(imageButton)を押したときの処理
    /// </summary>
    private void ImgBackBack_Click(object sender, EventArgs e)
    {
        BackBtnProcess();
    }

    /// <summary>
    /// 戻るボタンを押した時の詳細処理内容
    /// </summary>
    private void BackBtnProcess()
    {
        Navigation.PopAsync();
    }
}