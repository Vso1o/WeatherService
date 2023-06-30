using WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs;

namespace WeatherService.Core.DTOs.WeatherDTOs
{
    public class WeatherCurrentDto : WeatherItemBaseDto
    {
        public CoordDto Coord { get; set; }
        public SysDto Sys { get; set; }
        public string Base { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
