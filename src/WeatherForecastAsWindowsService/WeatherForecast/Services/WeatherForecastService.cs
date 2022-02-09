namespace WeatherForecast.Services;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Brokers;
using WeatherForecast.Entities;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IDbContextFactory<WeatherForecastDbContext> weatherForecastcontextFactory;

    public WeatherForecastService(IDbContextFactory<WeatherForecastDbContext> dbContextFactory)
    {
        this.weatherForecastcontextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<WeatherForecast>> GetAllWeatherForecasts()
    {
        using var context = weatherForecastcontextFactory.CreateDbContext();
        return await context.WeatherForecasts.ToListAsync();
    }


    public async Task InsertWeatherForecast(WeatherForecast entity)
    {
        using var context = weatherForecastcontextFactory.CreateDbContext();
        await context.WeatherForecasts.AddAsync(entity);
        return;
    }

}

