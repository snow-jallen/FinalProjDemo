using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Mobile.Views;

namespace WeatherApp.Mobile.ViewModels;

public partial class EntryViewModel : ObservableObject
{
    private readonly INavigationService navService;

    public EntryViewModel(INavigationService navService)
    {
        this.navService = navService;
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await navService.NavigateToAsync("..");
    }

    [ObservableProperty] private int tempC;
    [ObservableProperty] private DateTime date = DateTime.Today;

    [RelayCommand]
    private async Task AddForecastQueryParameters()
    {
        await navService.NavigateToAsync($"{nameof(ConfirmationPage)}?tempC={TempC}&date={Date:d}");
    }
}
