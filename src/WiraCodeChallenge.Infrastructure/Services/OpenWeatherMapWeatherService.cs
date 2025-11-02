using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WiraCodeChallenge.Application.Interfaces;
using WiraCodeChallenge.Domain.Entities;
using WiraCodeChallenge.Infrastructure.Configuration;

namespace WiraCodeChallenge.Infrastructure.Services;

public class OpenWeatherMapWeatherService(
    IHttpClientFactory httpClient, IOptions<OpenWeatherMapSettings> settings
    , ILogger<OpenWeatherMapAirQualityService> logger)
    : IWeatherService
{
    public async Task<Weather?> GetAsync(string cityName)
    {
        try
        {
            var url = $"{settings.Value.BaseUrl}/data/2.5/weather?q={Uri.EscapeDataString(cityName)}&appid={settings.Value.ApiKey}&units=metric";

            var client = httpClient.CreateClient();

            var response = await client.GetStringAsync(url);

            if (string.IsNullOrEmpty(response))
            {
                return null;
            }

            var convertedRes = JsonSerializer.Deserialize<WeatherApiResponse>(
                response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (convertedRes == null) { return null; }

            return new Weather
            {
                CityName = convertedRes.Name,
                Temperature = convertedRes.Main.Temp,
                Humidity = convertedRes.Main.Humidity,
                WindSpeed = convertedRes.Wind.Speed,
                Coordinates = new Coordinates
                {
                    Latitude = convertedRes.Coord.Lat,
                    Longitude = convertedRes.Coord.Lon
                }
            };
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex,
                 "HTTP request error while fetching weather data for city {CityName}", cityName);
            return null;
        }
    }
}
