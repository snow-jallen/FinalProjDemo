namespace Shared.Data;

public class WeatherForecastService : IWeatherForecastService
{
    public WeatherForecastService(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        this.httpClient = httpClientFactory.CreateClient("MyApi");
        this.config = config;
    }

    private readonly HttpClient httpClient;
    private readonly IConfiguration config;

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");
    }

    public async Task AddForecastAsync(int temperatureC, DateTime forecastDate)
    {
        var newForecast = new WeatherForecast { TemperatureC = temperatureC, Date = forecastDate };
        await httpClient.PostAsJsonAsync("/weatherforecast", newForecast);
    }
}