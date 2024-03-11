namespace ContractWork;

public partial class ContractPage : ContentPage
{
	public ContractPage()
	{
		InitializeComponent();
	}
	ContractStatus cs = null;
	TypeOfContract tpc = null;

	protected override void OnAppearing()
	{
		typePicker.ItemsSource = App.Database.GetItemsType().ToList();
		statusPicker.ItemsSource = App.Database.GetItemsStatus().ToList();
		var contract = (Contract)BindingContext;
		if (!String.IsNullOrEmpty(contract.Name))
		{
			statusPicker.SelectedItem = App.Database.GetItemStatus(contract.Id_Status);
			typePicker.SelectedItem = App.Database.GetItemType(contract.Id_Type);
		}
		base.OnAppearing();
	}

	private void typePicker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var pickert = (Picker)sender;
		int selectedIndex = pickert.SelectedIndex;
		if (selectedIndex != -1)
		{
			tpc = (TypeOfContract)pickert.ItemsSource[selectedIndex];
			typeId.Text = tpc.Id.ToString();
		}
	}

	private void statusPicker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var pickers = (Picker)sender;
		int selectedIndex = pickers.SelectedIndex;
		if (selectedIndex != -1)
		{
			cs = (ContractStatus)pickers.ItemsSource[selectedIndex];
			statusId.Text = cs.Id.ToString();
		}
	}
	private void SaveContract(object sender, EventArgs e)
	{
		var contract = (Contract)BindingContext;
		if (!String.IsNullOrEmpty(contract.Name) & !String.IsNullOrEmpty(tpc.Title) & !String.IsNullOrEmpty(cs.Status))
		{
			contract.Id_Type = tpc.Id;
			contract.Id_Status = cs.Id;
			App.Database.SaveItemContract(contract);
		}
		this.Navigation.PopAsync();
	}

	private void DeleteContract(object sender, EventArgs e)
	{
		var contract = (Contract)BindingContext;
		App.Database.DeleteItemContract(contract.Code);
		this.Navigation.PopAsync();
	}

	private void Cancel(object sender, EventArgs e)
	{
		this.Navigation.PopAsync();
	}
}