using WiraCodeChallenge.Domain.Entities;

namespace WiraCodeChallenge.Application.Interfaces;

public interface IAirQualityService
{
    Task<AirQuality?> GetAsync(double latitude, double longitude);
}
