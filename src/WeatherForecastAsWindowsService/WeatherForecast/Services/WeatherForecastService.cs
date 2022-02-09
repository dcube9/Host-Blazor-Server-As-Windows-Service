namespace WeatherForecast.Services;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Brokers;
using WeatherForecast.Entities;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly WeatherForecastDbContext weatherForecastDbContext;

    public WeatherForecastService()
    {
        var options = new DbContextOptionsBuilder<WeatherForecastDbContext>()
            .UseInMemoryDatabase("WeatherForecastDataBase")
            .Options;

        weatherForecastDbContext = new WeatherForecastDbContext(options);

    }

    public async Task<IEnumerable<WeatherForecast>> GetAllWeatherForecasts() => 
        await weatherForecastDbContext.WeatherForecasts.ToListAsync();


    public async Task InsertWeatherForecast(WeatherForecast entity) => await weatherForecastDbContext.WeatherForecasts.AddAsync(entity);

}

