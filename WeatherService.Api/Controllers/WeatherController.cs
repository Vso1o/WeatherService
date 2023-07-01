using Microsoft.AspNetCore.Mvc;
using WeatherService.Business.Exceptions;
using WeatherService.Business.Exceptions.Abstractions;
using WeatherService.Business.Services.Interfaces;

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

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather(string cityName)
        {
            var weather = await _weatherService.GetCurrentWeather(cityName);
            return Ok(weather);
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeatherForecast(string cityName)
        {
            var forecast = await _weatherService.GetWeatherForecast(cityName);
            return Ok(forecast);
        }
    }
}
