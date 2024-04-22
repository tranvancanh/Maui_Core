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
        //BindingContext = new NavigationPage(_appSystemSetting);
        //this.BindingContext = new AppSettingViewModel(Navigation);
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

    //private void customEtry_Focused(object sender, FocusEventArgs e)
    //{
    //    _appSystemSetting.customEtry_Focused();
    //}

    //private void customEtry_Focused(object sender, FocusEventArgs e)
    //{
    //    ResourceDictionary targetResource = Microsoft.Maui.Controls.Application.Current.Resources.MergedDictionaries.ElementAt(0);

    //    //this.BackgroundColor = (Color)targetResource["ActiveEntryBackColor"];
    //    var color = (Color)targetResource["Primary"];

    //    customEtry.BorderColor = color;
    //}
}