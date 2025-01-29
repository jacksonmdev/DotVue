namespace Application.Common.Models;

public class ForecastDto
{
    private class Mapping : Profile
    {
        public string? Summary { get; set; }
        public int TemperatureC { get; set; }
        
        public Mapping()
        {
            CreateMap<WeatherForecast, ForecastDto>();
        }
    }
}