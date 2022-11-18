using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyApi;
using MyApi.Data;

namespace ApiTests;

public class TestApi : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(ConfigureServices);
        builder.ConfigureLogging((WebHostBuilderContext context, ILoggingBuilder loggingBuilder) =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddConsole(options => options.IncludeScopes = true);
        });

    }

    protected virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IDataService, TestDataService>();
        services.AddAuthentication("Test")
            .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
    }
}

public class TestDataService : IDataService
{
    private List<WeatherForecast> weatherForecasts = new();
    public Task AddForecastAsync(WeatherForecast forecast)
    {
        weatherForecasts.Add(forecast);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
    {
        return Task.FromResult<IEnumerable<WeatherForecast>>(weatherForecasts);
    }
}
