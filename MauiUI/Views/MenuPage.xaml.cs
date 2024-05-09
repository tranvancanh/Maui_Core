namespace MauiUI.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();


        CompanyCode.Text = "CompanyCode";
        CompanyName.Text = "CompanyName";
        WarehouseCode.Text = "WarehouseCode";
        WarehouseName.Text = "WarehouseName";
        UserCode.Text = "UserCode";
        UserName.Text = "UserName";
    }

    private void OnLoginDataViewClicked(object sender, EventArgs e)
    {
        LoginDataViewToggle();
    }

    private void LoginDataViewToggle()
    {
        if (LoginDataView.IsVisible)
        {
            LoginDataViewIcon.Text = "\uf078";
            LoginDataView.IsVisible = false;
        }
        else
        {
            LoginDataViewIcon.Text = "\uf106";
            LoginDataView.IsVisible = true;
        }
        return;
    }


    private void LogoutButtonClicked(object sender, TappedEventArgs e)
    {

    }

    private void OnDeleteScanDataClicked(object sender, TappedEventArgs e)
    {

    }

    private void OnDeleteScanDataDoneClicked(object sender, EventArgs e)
    {

    }

    private void OnDeleteScanDataCancelClicked(object sender, EventArgs e)
    {

    }
}