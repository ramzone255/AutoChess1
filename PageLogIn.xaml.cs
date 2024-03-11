namespace ContractWork;

public partial class PageLogIn : ContentPage
{
	public PageLogIn()
	{
		InitializeComponent();
	}

	private async void btnlog_Clicked(object sender, EventArgs e)
	{
		string lg = EntLog.Text;
		string ps = EntPass.Text;
		try
		{ 
			if (!String.IsNullOrEmpty(EntLog.Text) && !String.IsNullOrEmpty(EntPass.Text))
			{
				App.Database.SignIn(lg, ps);
				DisplayAlert("�������� �����������", $"����� ���������� {EntLog.Text}", "��");
				await Navigation.PushAsync(new MainPage());
			}
			else
			{
				DisplayAlert("������", "������", "��");
			}
		}
		catch (Exception ex) 
		{
			DisplayAlert("�������� ������", $"{ex.Message}", "��");
		}
    }

	private async void btntoreg_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PageReg());
	}
}