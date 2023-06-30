using WeatherService.Core.DTOs.WeatherDTOs.InternalWeatherDTOs;

namespace WeatherService.Core.DTOs.WeatherDTOs
{
    public class WeatherForecastDto
    {
        public string Cod { get; set; }
        public string Message { get; set; }
        public int Cnt { get; set; }
        public List<WeatherForecastItemDto> List {  get; set; }
        public CityDto City { get; set; }
    }
}
