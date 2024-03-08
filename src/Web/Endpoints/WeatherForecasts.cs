using FctmsDemoApp.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace FctmsDemoApp.Web.Endpoints;

public class WeatherForecasts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetWeatherForecasts);
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender, [AsParameters] GetWeatherForecastsQuery query)
    {
        return await sender.Send(query);
    }
}
