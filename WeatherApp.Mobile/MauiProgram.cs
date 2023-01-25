using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Shared.Data;
using WeatherApp.Mobile.ViewModels;
using WeatherApp.Mobile.Views;

namespace WeatherApp.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
            builder.Services.AddSingleton<IAlertService, MauiAlertService>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<EntryViewModel>();
            builder.Services.AddSingleton<EntryPage>();
            builder.Services.AddSingleton<ConfirmationViewModel>();
            builder.Services.AddSingleton<ConfirmationPage>();
            builder.UseMauiCommunityToolkit();
            builder.Services.AddHttpClient("MyApi", client =>
            {
                client.BaseAddress = new Uri(Preferences.Get("MyApiBaseAddress", "https://localhost:7181"));
            });
            builder.Services.AddSingleton<INavigationService, ShellNavigationService>();

            Routing.RegisterRoute(nameof(EntryPage), typeof(EntryPage));
            Routing.RegisterRoute(nameof(ConfirmationPage), typeof(ConfirmationPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}