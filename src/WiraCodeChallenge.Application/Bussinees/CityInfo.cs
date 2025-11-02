using WiraCodeChallenge.Application.DTOs;
using WiraCodeChallenge.Application.Interfaces;

namespace WiraCodeChallenge.Application.Services;

public class CityInfo(IWeatherService weatherService,
        IAirQualityService airQualityService) : ICityInfo
{
    public async Task<CityInfoViewModel?> GetAsync(string cityName)
    {
        if (string.IsNullOrEmpty(cityName) || string.IsNullOrWhiteSpace(cityName))
        { return null; }

        var weatherData = await weatherService.GetAsync(cityName);
        if (weatherData == null) { return null; }

        var airQualityData = await airQualityService.GetAsync(
            weatherData.Coordinates.Latitude,
            weatherData.Coordinates.Longitude);

        if (airQualityData == null) { return null; }

        return new CityInfoViewModel
        {
            CityName = weatherData.CityName,
            Temperature = weatherData.Temperature,
            Humidity = weatherData.Humidity,
            WindSpeed = weatherData.WindSpeed,
            AirQualityIndex = airQualityData.AirQualityIndex,
            MajorPollutants = airQualityData.Pollutants,
            Latitude = weatherData.Coordinates.Latitude,
            Longitude = weatherData.Coordinates.Longitude
        };
    }
}
