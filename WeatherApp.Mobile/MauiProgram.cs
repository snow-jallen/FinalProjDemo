using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Shared.Data;
using WeatherApp.Mobile.ViewModels;

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
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.UseMauiCommunityToolkit();
            builder.Services.AddHttpClient("MyApi", client =>
            {
                client.BaseAddress = new Uri(Preferences.Get("MyApiBaseAddress", "https://localhost:7181"));                
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}