namespace ContractWork;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		contractList.ItemsSource = App.Database.GetItemsContract();
		base.OnAppearing();
	}
	private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		Contract selectedContract = (Contract)e.SelectedItem;
		ContractPage contractPage = new ContractPage();
		contractPage.BindingContext = selectedContract;
		await Navigation.PushAsync(contractPage);
	}

	private async void CreateContract(object sender, EventArgs e)
	{
		Contract contract = new Contract();
		ContractPage contractPage = new ContractPage();
		contractPage.BindingContext = contract;
		await Navigation.PushAsync(contractPage);
	}
}

