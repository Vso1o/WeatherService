using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs
{
    public class WeatherForecastItemDto : WeatherItemBaseDto
    {
        public SysForecastDto Sys { get; set; }
        [JsonProperty("dt_txt")]
        public string DtTxt { get; set; }
    }
}
