using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Mobile.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        private readonly IWeatherForecastService service;

        public MainViewModel(IWeatherForecastService service)
        {
            this.service = service;
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
