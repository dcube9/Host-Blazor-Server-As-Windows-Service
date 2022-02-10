namespace WeatherForecast.Services;

using WeatherForecast.Entities;

public interface IWeatherForecastService
{
    public List<WeatherForecast> WeatherForecasts { get; }

    Task GetAllWeatherForecasts();

    Task InsertWeatherForecast(WeatherForecast entity);
}

