using WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs;

namespace WeatherService.Core.DTOs.WeatherDTOs
{
    /// <summary>
    /// Class which represents returned repsonse from external API
    /// </summary>
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
