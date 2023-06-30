using Microsoft.AspNetCore.Mvc;
using WeatherService.Business.Exceptions;
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
            try
            {
                var weather = await _weatherService.GetCurrentWeather(cityName);
                return Ok(weather);
            }
            catch (WeatherServiceException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeatherForecast(string cityName)
        {
            try
            {
                var forecast = await _weatherService.GetWeatherForecast(cityName);
                return Ok(forecast);
            }
            catch (WeatherServiceException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }
    }
}
