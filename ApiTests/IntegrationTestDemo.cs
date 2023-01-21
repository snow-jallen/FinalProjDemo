using FluentAssertions;
using MyApi;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ApiTests;

public class IntegrationTestDemo
{
    [SetUp]
    public void Setup()
    {
    }

    [Test, Ignore("not needed")]
    public async Task TestWithAuth()
    {
        var api = new TestApi();
        var client = api.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        var response = await client.GetAsync("/weatherforecast");
        response.EnsureSuccessStatusCode();
    }

    [Test, Ignore("not needed")]
    public async Task StartWithNoneAddOneGetOneBack()
    {
        var api = new TestApi();
        var client = api.CreateClient();

        var initialForecasts = await client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("/weatherforecast");
        initialForecasts.Any().Should().BeFalse();

        var response = await client.PostAsJsonAsync("/weatherforecast", new WeatherForecast { Date = DateTime.Now, Summary = "weathery", TemperatureC = 12 });
        response.EnsureSuccessStatusCode();

        var newForecasts = await client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("/weatherforecast");
        newForecasts.Count().Should().Be(1);
    }

    [Test, Ignore("not needed")]
    public async Task StartWithNoneAddTwoGetTwoBack()
    {
        var api = new TestApi();
        var client = api.CreateClient();

        var initialForecasts = await client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("/weatherforecast");
        initialForecasts.Any().Should().BeFalse();

        var response = await client.PostAsJsonAsync("/weatherforecast", new WeatherForecast { Date = DateTime.Now, Summary = "weathery", TemperatureC = 12 });
        response.EnsureSuccessStatusCode();

        response = await client.PostAsJsonAsync("/weatherforecast", new WeatherForecast { Date = DateTime.Now, Summary = "weathery", TemperatureC = 12 });
        response.EnsureSuccessStatusCode();

        var newForecasts = await client.GetFromJsonAsync<IEnumerable<WeatherForecast>>("/weatherforecast");
        newForecasts.Count().Should().Be(2);
    }
}
