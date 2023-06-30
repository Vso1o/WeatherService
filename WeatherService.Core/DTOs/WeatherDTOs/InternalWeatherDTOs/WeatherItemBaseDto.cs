using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs
{
    public abstract class WeatherItemBaseDto
    {
        public List<WeatherDataDto> Weather { get; set; }
        public MainDto Main { get; set; }
        public int Visibility { get; set; }
        public WindDto Wind { get; set; }
        public CloudsDto Clouds { get; set; }
        public RainDto Rain { get; set; }
        public SnowDto Snow { get; set; }
        public long Dt { get; set; }
    }
}
