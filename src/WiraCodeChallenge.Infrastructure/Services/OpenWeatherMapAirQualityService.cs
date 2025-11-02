using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using WiraCodeChallenge.Application.Interfaces;
using WiraCodeChallenge.Domain.Entities;
using WiraCodeChallenge.Infrastructure.Configuration;
using WiraCodeChallenge.Infrastructure.Models.OpenWeatherMap;

namespace WiraCodeChallenge.Infrastructure.Services;

public class OpenWeatherMapAirQualityService(IHttpClientFactory httpClient,
            IOptions<OpenWeatherMapSettings> settings, ILogger<OpenWeatherMapAirQualityService> logger) : IAirQualityService
{
    public async Task<AirQuality?> GetAsync(double latitude, double longitude)
    {
        try
        {
            var url = $"{settings.Value.BaseUrl}/data/2.5/air_pollution?lat={latitude}&lon={longitude}&appid={settings.Value.ApiKey}";

            var client = httpClient.CreateClient();

            var response = await client.GetFromJsonAsync<AirPollutionApiResponse>(url);

            if (response == null || response.List.Count == 0)
            {
                return null;
            }

            var airQuality = response.List[0];
            var components = airQuality.Components;

            return new AirQuality
            {
                AirQualityIndex = airQuality.Aqi,
                Pollutants = new Dictionary<string, double>
                {
                    { "CO", components.Co },
                    { "NO", components.No },
                    { "NO2", components.No2 },
                    { "O3", components.O3 },
                    { "SO2", components.So2 },
                    { "PM2.5", components.Pm2_5 },
                    { "PM10", components.Pm10 },
                    { "NH3", components.Nh3 }
                },
                Coordinates = new Coordinates
                {
                    Latitude = response.Coord.Lat,
                    Longitude = response.Coord.Lon
                }
            };
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex,
                "HTTP request error while fetching air quality data for coordinates ({Latitude}, {Longitude})", latitude, longitude);
            return null;
        }
    }
}
