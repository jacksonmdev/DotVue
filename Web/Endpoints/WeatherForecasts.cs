using Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Carter;
using MediatR;

namespace Web.Endpoints;

public class WeatherForecasts : CarterModule
{
    public WeatherForecasts() : base("/weather")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("auth", () => "Hello from Get Process!").RequireAuthorization();

        app.MapGet("test", async (ISender sender) =>
            Results.Ok(await sender.Send(new GetWeatherForecastsQuery())));
    }
}