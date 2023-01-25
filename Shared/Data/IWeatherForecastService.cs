namespace Shared.Data
{
    public interface IWeatherForecastService
    {
        Task AddForecastAsync(int temperatureC, DateTime forecastDate);
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}