using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApi.Data;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDataService dataService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDataService dataService)
        {
            _logger = logger;
            this.dataService = dataService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await dataService.GetForecastsAsync();
        }

        [Authorize]
        [HttpPost()]
        public async Task Post(WeatherForecast weatherForecast)
        {
            await dataService.AddForecastAsync(weatherForecast);
        }
    }
}