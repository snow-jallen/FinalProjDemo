using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Data;

namespace WeatherApp.Mobile.ViewModels;

[QueryProperty(nameof(TemperatureC), "tempC")]
[QueryProperty(nameof(ForecastDate), "date")]
public partial class ConfirmationViewModel : ObservableObject
{
    private readonly INavigationService navService;
    private readonly IWeatherForecastService forecastService;
    private readonly IAlertService alertService;

    public ConfirmationViewModel(INavigationService navService, IWeatherForecastService forecastService, IAlertService alertService)
    {
        this.navService = navService;
        this.forecastService = forecastService;
        this.alertService = alertService;
    }

    [ObservableProperty] private int temperatureC;
    [ObservableProperty] private DateTime forecastDate;

    [RelayCommand]
    private async Task AddForecast()
    {
        var msg = new PopupMessage
        {
            Title = "Are you really sure?",
            Message = "Seriously, this is going to get added to the database.  Really?",
            YesMessage = "Yup, I'm certain",
            NoMessage = "Shoot - that was close, don't do it!"
        };
        alertService.ShowConfirmation("Are you really sure?", "Seriously, this is going to be added to the database.  really?", async (ans) =>
        {
            if (ans)
            {
                await forecastService.AddForecastAsync(TemperatureC, ForecastDate);
                alertService.ShowAlert("Done", "Forecast added.");
                await navService.NavigateToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                alertService.ShowAlert("Cancelled", "Whew, that was a close one!");
            }
        }, "Yup, I'm certain", "Shoot - that was close, don't do it!");
    }

    [RelayCommand]
    private async Task Cancel()
    {
        await navService.NavigateToAsync("..");
    }

    public event EventHandler<PopupMessage> ConfirmationRequested;
}

public class PopupMessage
{
    public bool Result { get; set; }
    public string Title { get; set; } = "Message";
    public string Message { get; set; }
    public string YesMessage { get; set; } = "Ok";
    public string NoMessage { get; set; } = "Cancel";
}
