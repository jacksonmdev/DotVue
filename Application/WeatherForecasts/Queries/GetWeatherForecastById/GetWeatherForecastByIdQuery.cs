using Application.Common.Mappings;
using Application.Common.Models;

namespace Application.WeatherForecasts.Queries.GetWeatherForecastById;

public record GetWeatherForecastByIdQuery : IRequest<IEnumerable<ForecastDto>>
{
    public required int Id { get; set; }
}

public class GetWeatherForecastsByIdQueryHandler : IRequestHandler<GetWeatherForecastByIdQuery, IEnumerable<ForecastDto>>
{
    private readonly IMapper _mapper;

    public GetWeatherForecastsByIdQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ForecastDto>> Handle(GetWeatherForecastByIdQuery request, CancellationToken cancellationToken)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        var rng = new Random();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = summaries[rng.Next(summaries.Length)]
        }).AsQueryable().ProjectTo<ForecastDto>(_mapper.ConfigurationProvider).AsEnumerable();
    }
}