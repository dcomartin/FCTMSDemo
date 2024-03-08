namespace FctmsDemoApp.Application.WeatherForecasts.Queries.GetWeatherForecasts;

public record GetWeatherForecastsQuery() : IRequest<IEnumerable<WeatherForecast>>
{
    public string Weather { get; set; } = "";
}

public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecast>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly WeatherForecast[] Data = new[]
    {
        new WeatherForecast() { Date = new DateTime(2024, 01, 12), TemperatureC = -11, Summary = "Bracing", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 13), TemperatureC = -1, Summary = "Chilly", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 14), TemperatureC = -14, Summary = "Mild", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 15), TemperatureC = 41, Summary = "Freezing", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 16), TemperatureC = 11, Summary = "Bracing", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 17), TemperatureC = -14, Summary = "Chilly", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 18), TemperatureC = 35, Summary = "Hot", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 19), TemperatureC = 31, Summary = "Cool", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 20), TemperatureC = 15, Summary = "Hot", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 21), TemperatureC = 26, Summary = "Chilly", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 22), TemperatureC = -11, Summary = "Warm", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 23), TemperatureC = 5, Summary = "Freezing", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 24), TemperatureC = 27, Summary = "Sweltering", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 25), TemperatureC = -8, Summary = "Freezing", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 26), TemperatureC = 41, Summary = "Cool", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 27), TemperatureC = -20, Summary = "Hot", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 28), TemperatureC = 39, Summary = "Sweltering", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 29), TemperatureC = -19, Summary = "Warm", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 30), TemperatureC = -13, Summary = "Freezing", },
        new WeatherForecast() { Date = new DateTime(2024, 01, 31), TemperatureC = 39, Summary = "Warm", }, 
    };

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        var rng = new Random();

        // Change array contents or to another dataset as needed for mocking
        var result = Data.AsEnumerable();

        if (string.IsNullOrWhiteSpace(request.Weather) == false)
        {
            result = result.Where(x => request.Weather.Equals(x.Summary, StringComparison.InvariantCultureIgnoreCase));
        }
        
        return result;
    }
}
