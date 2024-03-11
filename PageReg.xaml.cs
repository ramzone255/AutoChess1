using System.ComponentModel.DataAnnotations.Schema;

namespace ContractWork;

public partial class PageReg : ContentPage
{
	public PageReg()
	{
		InitializeComponent();
	}

	private async void btnreg_Clicked(object sender, EventArgs e)
	{
		string enlog = EntLog.Text;
		string enpass = EntPass.Text;
		string enpass2 = EntPass2.Text;
		try
		{
			if (enlog != null && enpass.Length > 5)
			{
				if (enlog.Contains("@") || enlog.Contains(".") || enlog.Contains("ru") || enlog.Contains("com"))
				{
					if (enpass2 == enpass)
					{
						App.Database.CreateNewUser(enlog, enpass, enpass2);
						await Navigation.PushAsync(new PageLogIn());
					}
					else
					{
						DisplayAlert("Ошибка", "УСПЕШНАЯ РЕГИСТРАЦИЯ", "ОК");
					}
				}
				else
				{
					DisplayAlert("Ошибка", "Такой почты не существует", "ОК");
				}
			}
			else
			{
				DisplayAlert("Ошибка", "Поля заполнены неправильно", "ОК");
			}
		}
		catch (Exception ex)
		{
			DisplayAlert("Системня ошибка", $"{ex.Message}", "ОК");
		}
    }
}