using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs;

namespace WeatherService.Core.DTOs.WeatherDTOs
{
    /// <summary>
    /// Class which limits external API response to one specified in technical requirements
    /// </summary>
    public class CurrentWeatherResponseDto
    {
        public DateTime? Date { get; set; }
        public double WindSpeed { get; set; }
        public double Clouds { get; set;}
        public double? Temperature { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
    }
}
