namespace WeatherForecast.Brokers;

using Microsoft.EntityFrameworkCore;
using WeatherForecast.Entities;

public class WeatherForecastDbContext : DbContext
{
    public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
    : base(options)
    {
        this.EnsureSeedData(); // Initial Seed
    }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WeatherForecastDataBase");
    }
}
