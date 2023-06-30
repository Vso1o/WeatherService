using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs
{
    public class RainDto
    {
        [JsonProperty("1h")]
        public double Rain1H { get; set; }
        [JsonProperty("3h")]
        public double Rain3H { get; set; }
    }
}
