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
    /// �f�t�H���g�߂�{�^���𖳌���
    /// </summary>
    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    /// <summary>
    /// �߂�{�^��(imageButton)���������Ƃ��̏���
    /// </summary>
    private void ImgBackBack_Click(object sender, EventArgs e)
    {
        BackBtnProcess();
    }

    /// <summary>
    /// �߂�{�^�������������̏ڍ׏������e
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