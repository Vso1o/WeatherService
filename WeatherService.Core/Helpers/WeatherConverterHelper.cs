using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Core.DTOs.WeatherDTOs;

namespace WeatherService.Core.Helpers
{
    public static class WeatherConverterHelper
    {
        public static CurrentWeatherResponseDto GetCurrentWeatherResponseDto(WeatherCurrentDto weatherCurrentDto)
        {
            return new CurrentWeatherResponseDto
            {
                Clouds = weatherCurrentDto.Clouds.All,
                WindSpeed = weatherCurrentDto.Wind.Speed,
                Temperature = weatherCurrentDto.Main.Temp,
                MaxTemperature = weatherCurrentDto.Main.TempMax,
                MinTemperature = weatherCurrentDto.Main.TempMin,
                Date = DateTimeOffset.FromUnixTimeSeconds(weatherCurrentDto.Dt).LocalDateTime
            };
        }

        public static ForecastWeatherResponseDto GetForecastWeatherResponseDto(WeatherForecastDto weatherForecastDto)
        {
            var response = new ForecastWeatherResponseDto();
            foreach (var weatherItem in weatherForecastDto.List)
            {
                response.ForecastWeatherResponseDtos.Add(new CurrentWeatherResponseDto {
                    Clouds = weatherItem.Clouds.All,
                    WindSpeed = weatherItem.Wind.Speed,
                    Temperature = weatherItem.Main.Temp,
                    MaxTemperature = weatherItem.Main.TempMax,
                    MinTemperature = weatherItem.Main.TempMin,
                    Date = DateTimeOffset.FromUnixTimeSeconds(weatherItem.Dt).LocalDateTime
                });
            }
            return response;
        }
    }
}
