using WeatherService.Core.DTOs.WeatherDTOs;

namespace WeatherService.Business.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetCurrentWeather(string cityName);
        Task<WeatherForecastDto> GetWeatherForecast(string cityName);
    }
}
