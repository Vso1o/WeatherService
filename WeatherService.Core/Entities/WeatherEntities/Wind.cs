using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Core.Entities.WeatherEntities
{
    public class Wind
    {
        public WindSpeed Speed { get; set; }
        public double Gusts { get; set; }
        public WindDirection Direction { get; set; }
    }
}
