using WiraCodeChallenge.Application.DTOs;

namespace WiraCodeChallenge.Application.Interfaces;

public interface ICityInfo
{
    Task<CityInfoViewModel?> GetAsync(string cityName);
}
