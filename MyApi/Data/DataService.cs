using Microsoft.EntityFrameworkCore;

namespace MyApi.Data;

public interface IDataService
{
    Task<IEnumerable<WeatherForecast>> GetForecastsAsync();
    Task AddForecastAsync(WeatherForecast forecast);
}

public class EfCoreDataService : IDataService
{
    private readonly AppDbContext dbContext;

    public EfCoreDataService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task AddForecastAsync(WeatherForecast forecast)
    {
        await dbContext.WeatherForecasts.AddAsync(forecast);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
    {
        return await dbContext.WeatherForecasts.ToListAsync();
    }
}