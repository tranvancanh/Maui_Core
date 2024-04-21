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
}