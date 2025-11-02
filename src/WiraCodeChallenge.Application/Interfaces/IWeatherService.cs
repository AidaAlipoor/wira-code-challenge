using WiraCodeChallenge.Domain.Entities;

namespace WiraCodeChallenge.Application.Interfaces;

public interface IWeatherService
{
    Task<Weather?> GetAsync(string cityName);
}
