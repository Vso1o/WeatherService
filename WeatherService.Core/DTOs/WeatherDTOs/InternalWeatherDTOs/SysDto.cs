using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs
{
    /// <summary>
    /// The Data Transfer Object represents the Sys parameter. 
    /// It is important to note that certain internal parameters, such as 'id,' 
    /// provided by the API, are not included here due to their redundancy
    /// </summary>
    public class SysDto
    {
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
