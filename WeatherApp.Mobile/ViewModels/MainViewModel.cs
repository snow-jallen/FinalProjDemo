using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Data;
using WeatherApp.Mobile.Views;

namespace WeatherApp.Mobile.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        private readonly IWeatherForecastService service;
        private readonly INavigationService navService;

        public MainViewModel(IWeatherForecastService service, INavigationService navService)
        {
            this.service = service;
            this.navService = navService;
        }

        [ObservableProperty]
        private double temperature = 200.0;

        [ObservableProperty]
        private DateTime selectedDate;

        partial void OnSelectedDateChanged(DateTime value)
        {
            getTemperatureAsync(value);
            //:)
        }

        [RelayCommand]
        private async Task GoToEntryPage()
        {
            await navService.NavigateToAsync(nameof(EntryPage));
        }

        private async Task getTemperatureAsync(DateTime value)
        {
            var forecast = await service.GetForecastAsync(value);
            Temperature = forecast.Single(f => f.Date == value).TemperatureF;
        }

        [RelayCommand]
        private async Task Loaded()
        {
            var forecast = await service.GetForecastAsync(DateTime.Now);
            Temperature = forecast[0].TemperatureF;
        }
    }
}
