// using Application.WeatherForecasts.Queries.GetWeatherForecasts;
// using Carter;
// using MediatR;
//
// namespace Web.Endpoints;
//
// public class WeatherForecasts : CarterModule
// {
//     public WeatherForecasts() : base("/weather")
//     {
//         WithTags("Weather Forecast");
//     }
//
//     public override void AddRoutes(IEndpointRouteBuilder app)
//     {
//         app.MapGet("private", () => "You should not be seeing this!").RequireAuthorization();
//
//         app.MapGet("public", async (ISender sender) =>
//             await sender.Send(new GetWeatherForecastsQuery()));
//     }
// }