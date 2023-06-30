using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Core.Entities.WeatherEntities;

namespace WeatherService.Core.DTOs.WeatherDTOs
{
    public class WeatherDto
    {
        public City City { get; set; }
        public Temperature Temperature { get; set; }
        public Temperature FeelsLike { get; set; }
        public Humidity Humidity { get; set; }
        public Pressure Pressure { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Visibility { get; set; }
        public Precipitation Precipitation { get; set; }
        public WeatherData Weather { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
