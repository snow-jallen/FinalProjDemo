using WeatherApp.Mobile.ViewModels;

namespace WeatherApp.Mobile.Views;

public partial class ConfirmationPage : ContentPage
{
    public ConfirmationPage(ConfirmationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}