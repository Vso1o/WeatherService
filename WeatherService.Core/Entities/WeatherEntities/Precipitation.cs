using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Core.Entities.WeatherEntities
{
    public class Precipitation
    {
        public double Value { get; set; }
        public string Mode { get; set; }
        public string Unit { get; set; }
    }
}
