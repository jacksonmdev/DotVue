namespace Application.Common.Models;

public class ForecastDto
{
    public string? Summary { get; set; }
    public int TemperatureC { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<WeatherForecast, ForecastDto>();
        }
    }
}