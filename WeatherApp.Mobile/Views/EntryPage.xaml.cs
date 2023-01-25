using WeatherApp.Mobile.ViewModels;

namespace WeatherApp.Mobile.Views;

public partial class EntryPage : ContentPage
{
	public EntryPage(EntryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}