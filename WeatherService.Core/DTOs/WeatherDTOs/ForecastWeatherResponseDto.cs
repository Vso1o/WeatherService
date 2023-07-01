using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Core.DTOs.WeatherDTOs
{
    /// <summary>
    /// Class which limits external API response to one specified in technical requirements
    /// </summary>
    public class ForecastWeatherResponseDto
    {
        public List<CurrentWeatherResponseDto> ForecastWeatherResponseDtos { get; set; } = new List<CurrentWeatherResponseDto>();
    }
}
