namespace WeatherForecast.Services;

using WeatherForecast.Entities;

public interface IWeatherForecastService
{
    List<WeatherForecast> WeatherForecasts { get; }

    Task GetAllWeatherForecasts();

    Task InsertWeatherForecast(WeatherForecast entity);
}

