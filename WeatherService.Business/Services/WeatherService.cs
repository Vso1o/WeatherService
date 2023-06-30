using WeatherService.Business.Exceptions;
using WeatherService.Business.Services.Interfaces;
using WeatherService.Core.DTOs.WeatherDTOs;
using Newtonsoft.Json;

namespace WeatherService.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        private readonly string _apiKey = "2cfd27333d97bfc79ac756705c42284c";
        private readonly string _baseUri = "https://api.openweathermap.org/data/2.5";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherDto> GetCurrentWeather(string cityName)
        {
            string apiUrl = $"{_baseUri}/weather?q={Uri.EscapeDataString(cityName)}&appid={_apiKey}&units=metric";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
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

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
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

        private WeatherDto ParseCurrentWeather(string json)
        {
            WeatherDto weather = JsonConvert.DeserializeObject<WeatherDto>(json);
            return weather;
        }

        private WeatherForecastDto ParseWeatherForecast(string json)
        {
            WeatherForecastDto weather = JsonConvert.DeserializeObject<WeatherForecastDto>(json);
            return weather;
        }
    }
}
