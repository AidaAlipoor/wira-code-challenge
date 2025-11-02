using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WiraCodeChallenge.Application.Interfaces;
using WiraCodeChallenge.Infrastructure.Configuration;
using WiraCodeChallenge.Infrastructure.Services;

namespace WiraCodeChallenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<OpenWeatherMapSettings>(
            configuration.GetSection("OpenWeatherMap"));

        services.AddHttpClient();
        services.AddScoped<IWeatherService, OpenWeatherMapWeatherService>();
        services.AddScoped<IAirQualityService, OpenWeatherMapAirQualityService>();

        return services;
    }
}
