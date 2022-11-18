using System.Net.Http.Headers;

namespace ApiTests;

public class IntegrationTestDemo
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestWithAuth()
    {
        var api = new TestApi();
        var client = api.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        var response = await client.GetAsync("/weatherforecast");
        response.EnsureSuccessStatusCode();
    }

}
