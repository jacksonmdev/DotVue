using Application.Common.Models;

namespace Application.WeatherForecasts.Queries.GetWeatherForecastById;

public record GetWeatherForecastByIdQuery : IRequest<IEnumerable<WeatherForecast>>
{
    public required int Id { get; set; }
}

public class GetWeatherForecastsByIdQueryHandler : IRequestHandler<GetWeatherForecastByIdQuery, IEnumerable<WeatherForecast>>
{
    public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastByIdQuery request, CancellationToken cancellationToken)
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
        });
    }
}