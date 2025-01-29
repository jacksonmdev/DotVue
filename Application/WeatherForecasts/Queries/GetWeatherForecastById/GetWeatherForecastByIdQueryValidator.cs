namespace Application.WeatherForecasts.Queries.GetWeatherForecastById;

public class GetWeatherForecastByIdQueryValidator : AbstractValidator<GetWeatherForecastByIdQuery>
{
    public GetWeatherForecastByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id is required.");
    }
}