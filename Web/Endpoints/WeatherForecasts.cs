
using Application.Common.Models;
using Application.WeatherForecasts.Queries.GetWeatherForecastById;
using Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using RouteBase = Web.Common.RouteBase;

namespace Web.Endpoints;

public class WeatherForecasts : RouteBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetWeatherForecastsPublic, "public")
            .MapPost(GetWeatherForecastsPublicWithPayload, "forecast");
        
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetWeatherForecastsPrivate, "private");
    }

    public async Task<Ok<IEnumerable<WeatherForecast>>> GetWeatherForecastsPublic(ISender sender)
    {
        var forecasts = await sender.Send(new GetWeatherForecastsQuery());
        return TypedResults.Ok(forecasts);
    }
    
    public async Task<Ok<IEnumerable<WeatherForecast>>> GetWeatherForecastsPublicWithPayload(ISender sender, [FromBody] GetWeatherForecastByIdQuery query)
    {
        var forecasts = await sender.Send(query);
        return TypedResults.Ok(forecasts);
    }
    
    public async Task<Ok<IEnumerable<WeatherForecast>>> GetWeatherForecastsPrivate(ISender sender)
    {
        var forecasts = await sender.Send(new GetWeatherForecastsQuery());
        return TypedResults.Ok(forecasts);
    }
}