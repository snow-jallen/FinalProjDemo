namespace FinalProjDemo.Data
{
    public class WeatherForecastService
    {
        public WeatherForecastService(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        private readonly HttpClient httpClient;
        private readonly IConfiguration config;

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");
        }
    }
}