using Microsoft.Extensions.DependencyInjection;
using WiraCodeChallenge.Application.Interfaces;
using WiraCodeChallenge.Application.Services;

namespace WiraCodeChallenge.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<ICityInfo, CityInfo>();
        return services;
    }
}
