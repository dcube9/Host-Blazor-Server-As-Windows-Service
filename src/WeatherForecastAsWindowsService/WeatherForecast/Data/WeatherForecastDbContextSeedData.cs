namespace WeatherForecast.Data;

using WeatherForecast.Brokers;
using WeatherForecast.Entities;


public static class WeatherForecastDbContextSeedData
{
    static object synchlock = new();
    static volatile bool seeded = false;

    private static readonly string[] Summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static void EnsureSeedData(this WeatherForecastDbContext context)
    {
        if (!seeded && context.WeatherForecasts.Count() == 0)
        {
            lock (synchlock)
            {
                if (!seeded)
                {
                    var weatherForecasts = GenerateWeatherForecasts(DateTime.Now);

                    context.WeatherForecasts.AddRange(weatherForecasts);

                    context.SaveChanges();
                    seeded = true;
                }
            }
        }   
    }
    public static WeatherForecast[] GenerateWeatherForecasts(DateTime startDate)
    {
        return Enumerable.Range(1, 1)
            .Select(index => GenerateRandomWeatherForecast(startDate, index))
            .ToArray();
    }

    public static WeatherForecast GenerateRandomWeatherForecast(DateTime startDate, int index)
    {
        return new WeatherForecast
        {
            Id = 0,
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }
}