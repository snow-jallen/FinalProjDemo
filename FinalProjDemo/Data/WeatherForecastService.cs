namespace FinalProjDemo.Data
{
    public class WeatherForecastService
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
    }
}