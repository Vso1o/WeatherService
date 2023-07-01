using Microsoft.AspNetCore.Mvc;
using WeatherService.Business.Exceptions;
using WeatherService.Business.Exceptions.Abstractions;
using WeatherService.Business.Services.Interfaces;
using WeatherService.Core.Helpers;

namespace WeatherService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get weather in specific city
        /// </summary>
        /// <param name="cityName">Name of city</param>
        /// <returns></returns>
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather(string cityName)
        {
            var weather = await _weatherService.GetCurrentWeather(cityName);
            var result = WeatherConverterHelper.GetCurrentWeatherResponseDto(weather);
            return Ok(result);
        }

        /// <summary>
        /// Get weather in specific city, returns full results
        /// </summary>
        /// <param name="cityName">Name of city</param>
        /// <returns></returns>
        [HttpGet("currentFull")]
        public async Task<IActionResult> GetCurrentFullWeather(string cityName)
        {
            var weather = await _weatherService.GetCurrentWeather(cityName);
            return Ok(weather);
        }

        /// <summary>
        /// Get forecast for specific city
        /// </summary>
        /// <param name="cityName">Name of city</param>
        /// <returns></returns>
        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeatherForecast(string cityName)
        {
            var forecast = await _weatherService.GetWeatherForecast(cityName);
            var result = WeatherConverterHelper.GetForecastWeatherResponseDto(forecast);
            return Ok(result);
        }

        /// <summary>
        /// Get forecast for specific city, returns full results
        /// </summary>
        /// <param name="cityName">Name of city</param>
        /// <returns></returns>
        [HttpGet("forecastFull")]
        public async Task<IActionResult> GetWeatherFullForecast(string cityName)
        {
            var forecast = await _weatherService.GetWeatherForecast(cityName);
            return Ok(forecast);
        }
    }
}
