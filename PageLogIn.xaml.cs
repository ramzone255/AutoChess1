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
				DisplayAlert("Успешная авторизация", $"Добро пожаловать {EntLog.Text}", "ОК");
				await Navigation.PushAsync(new MainPage());
			}
			else
			{
				DisplayAlert("Ошибка", "Ошибка", "ОК");
			}
		}
		catch (Exception ex) 
		{
			DisplayAlert("Системня ошибка", $"{ex.Message}", "ОК");
		}
    }

	private async void btntoreg_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PageReg());
	}
}