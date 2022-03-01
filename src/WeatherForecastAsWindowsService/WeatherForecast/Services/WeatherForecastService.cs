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

    public List<WeatherForecast> WeatherForecasts { get; private set; }

    public async Task GetAllWeatherForecasts()
    {
        using var context = weatherForecastcontextFactory.CreateDbContext();
        WeatherForecasts =  await context.WeatherForecasts.ToListAsync();
    }


    public async Task InsertWeatherForecast(WeatherForecast entity)
    {
        using var context = weatherForecastcontextFactory.CreateDbContext();
        await context.WeatherForecasts.AddAsync(entity);
        return;
    }
}

