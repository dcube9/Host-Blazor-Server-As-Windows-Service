namespace WeatherForecast.Services;

using WeatherForecast.Entities;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> GetAllWeatherForecasts();

    Task InsertWeatherForecast(WeatherForecast entity);
}

