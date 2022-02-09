namespace WeatherForecast.Workers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WeatherForecast.Brokers;
using WeatherForecast.Entities;


public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly IDbContextFactory<WeatherForecastDbContext> contextFactory;

    public Worker(ILogger<Worker> logger, IDbContextFactory<WeatherForecastDbContext> contextFactory)
    {
        this.logger = logger;
        this.contextFactory = contextFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            using (var context = contextFactory.CreateDbContext()) 
            {
                var quanti = await context.WeatherForecasts.CountAsync();

                if (quanti <= 100)
                {
                    await context.WeatherForecasts.AddAsync(WeatherForecastDbContextSeedData.GenerateRandomWeatherForecast(DateTime.Now, 0));
                    await context.SaveChangesAsync();
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
