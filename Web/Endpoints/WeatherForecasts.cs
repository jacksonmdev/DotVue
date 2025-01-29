
using Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Http.HttpResults;
using Web.Common;
using RouteBase = Web.Common.RouteBase;

namespace Web.Endpoints;

public class WeatherForecasts : RouteBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetWeatherForecastsPublic, "/public");
        
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetWeatherForecastsPrivate, "/private");
    }

    public async Task<Ok<IEnumerable<WeatherForecast>>> GetWeatherForecastsPublic(ISender sender)
    {
        var forecasts = await sender.Send(new GetWeatherForecastsQuery());
        return TypedResults.Ok(forecasts);
    }
    
    public async Task<Ok<IEnumerable<WeatherForecast>>> GetWeatherForecastsPrivate(ISender sender)
    {
        var forecasts = await sender.Send(new GetWeatherForecastsQuery());
        return TypedResults.Ok(forecasts);
    }
}