using WeatherService.Business.Exceptions;
using WeatherService.Business.Services.Interfaces;
using WeatherService.Core.DTOs.WeatherDTOs;
using Newtonsoft.Json;
using WeatherService.Business.Utils;
using WeatherService.Business.Utils.Interfaces;
using Microsoft.Extensions.Configuration;

namespace WeatherService.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpUtil _httpUtil;

        private readonly string _apiKey;
        private readonly string _baseUri;

        public WeatherService(IHttpUtil httpUtil, IConfiguration configuration)
        {
            _httpUtil = httpUtil;
            _apiKey = configuration.GetSection("OpenWeatherApiSettings")["apiKey"] ?? "2cfd27333d97bfc79ac756705c42284c";
            _baseUri = configuration.GetSection("OpenWeatherApiSettings")["baseUri"] ?? "https://api.openweathermap.org/data/2.5";
        }

        public async Task<WeatherCurrentDto> GetCurrentWeather(string cityName)
        {
            string apiUrl = $"{_baseUri}/weather?q={Uri.EscapeDataString(cityName)}&appid={_apiKey}&units=metric";

            HttpResponseMessage response = await _httpUtil.GetAsync(apiUrl);

            var res = response.Content.ToString();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var weather = ParseCurrentWeather(json);
                return weather;
            }
            else
            {
                throw new WeatherServiceException(response.StatusCode, $"Failed to get current weather. StatusCode: {response.StatusCode}");
            }
        }

        public async Task<WeatherForecastDto> GetWeatherForecast(string cityName)
        {
            string apiUrl = $"{_baseUri}/forecast?q={Uri.EscapeDataString(cityName)}&appid={_apiKey}&units=metric";

            HttpResponseMessage response = await _httpUtil.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var forecast = ParseWeatherForecast(json);
                return forecast;
            }
            else
            {
                throw new WeatherServiceException(response.StatusCode, $"Failed to get weather forecast. StatusCode: {response.StatusCode}");
            }
        }

        private WeatherCurrentDto ParseCurrentWeather(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ParsingException("Invalid JSON string.", nameof(json));
            }
            try
            {
                WeatherCurrentDto weather = JsonConvert.DeserializeObject<WeatherCurrentDto>(json);
                return weather;
            }
            catch (Exception ex)
            {
                throw new ParsingException("Failed to parse the JSON string from external API.", nameof(json), ex);
            }
        }

        private WeatherForecastDto ParseWeatherForecast(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("Invalid JSON string.", nameof(json));
            }
            try
            {
                WeatherForecastDto weather = JsonConvert.DeserializeObject<WeatherForecastDto>(json);
                return weather;
            }
            catch (Exception ex)
            {
                throw new ParsingException("Failed to parse the JSON string from external API.", nameof(json), ex);
            }
        }
    }
}
