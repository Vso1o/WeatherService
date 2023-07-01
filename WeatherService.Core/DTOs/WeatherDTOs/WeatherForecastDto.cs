using WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs;

namespace WeatherService.Core.DTOs.WeatherDTOs
{
    /// <summary>
    /// Class which represents returned repsonse from external API
    /// </summary>
    public class WeatherForecastDto
    {
        public string Cod { get; set; }
        public string Message { get; set; }
        public int Cnt { get; set; }
        public List<WeatherForecastItemDto> List {  get; set; }
        public CityDto City { get; set; }
    }
}
