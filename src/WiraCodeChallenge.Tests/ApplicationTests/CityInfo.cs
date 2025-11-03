using Moq;
using WiraCodeChallenge.Application.Interfaces;
using WiraCodeChallenge.Domain.Entities;

namespace WiraCodeChallenge.Application.Tests.Services;

public class CityInfoTests
{
    private readonly Mock<IWeatherService> _mockWeatherService;
    private readonly Mock<IAirQualityService> _mockAirQualityService;
    private readonly Application.Services.CityInfo _cityInfoService;

    public CityInfoTests()
    {
        _mockWeatherService = new Mock<IWeatherService>();
        _mockAirQualityService = new Mock<IAirQualityService>();
        _cityInfoService = new Application.Services.CityInfo(
            _mockWeatherService.Object, _mockAirQualityService.Object);
    }

    [Fact]
    public async Task GetAsync_WithValidCityName_ReturnsCityInfoDto()
    {
        // Arrange
        var cityName = "Tehran";
        var weatherData = new Weather
        {
            CityName = "Tehran",
            Temperature = 25.5,
            Humidity = 60,
            WindSpeed = 3.5,
            Coordinates = new Coordinates
            {
                Latitude = 35.6892,
                Longitude = 51.3890
            }
        };

        var airQualityData = new AirQuality
        {
            AirQualityIndex = 3,
            Pollutants = new Dictionary<string, double>
            {
                { "pm2_5", 15.5 },
                { "pm10", 25.0 },
                { "o3", 50.0 }
            },
            Coordinates = new Coordinates
            {
                Latitude = 35.6892,
                Longitude = 51.3890
            }
        };

        _mockWeatherService
            .Setup(s => s.GetAsync(cityName))
            .ReturnsAsync(weatherData);

        _mockAirQualityService
            .Setup(s => s.GetAsync(
                weatherData.Coordinates.Latitude, weatherData.Coordinates.Longitude))
            .ReturnsAsync(airQualityData);

        // Act
        var result = await _cityInfoService.GetAsync(cityName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Tehran", result.CityName);
        Assert.Equal(25.5, result.Temperature);
        Assert.Equal(60, result.Humidity);
        Assert.Equal(3.5, result.WindSpeed);
        Assert.Equal(3, result.AirQualityIndex);
        Assert.Equal(3, result.MajorPollutants.Count);
        Assert.Equal(15.5, result.MajorPollutants["pm2_5"]);
        Assert.Equal(35.6892, result.Latitude);
        Assert.Equal(51.3890, result.Longitude);

        _mockWeatherService.Verify(s => s.GetAsync(cityName), Times.Once);
        _mockAirQualityService.Verify(
            s => s.GetAsync(weatherData.Coordinates.Latitude, weatherData.Coordinates.Longitude),
            Times.Once);
    }

    [Fact]
    public async Task GetAsync_WithNullOrEmptyCityName_ReturnsNull()
    {
        // Arrange & Act
        var resultNull = await _cityInfoService.GetAsync(null);
        var resultEmpty = await _cityInfoService.GetAsync(string.Empty);
        var resultWhitespace = await _cityInfoService.GetAsync("   ");

        // Assert
        Assert.Null(resultNull);
        Assert.Null(resultEmpty);
        Assert.Null(resultWhitespace);

        _mockWeatherService.Verify(s => s.GetAsync(It.IsAny<string>()), Times.Never);
        _mockAirQualityService.Verify(
            s => s.GetAsync(It.IsAny<double>(), It.IsAny<double>()),
            Times.Never);
    }

    [Fact]
    public async Task GetAsync_WhenAirQualityServiceReturnsNull_ReturnsNull()
    {
        // Arrange
        var cityName = "Tehran";
        var weatherData = new Weather
        {
            CityName = "Tehran",
            Temperature = 25.5,
            Humidity = 60,
            WindSpeed = 3.5,
            Coordinates = new Coordinates
            {
                Latitude = 35.6892,
                Longitude = 51.3890
            }
        };

        _mockWeatherService
            .Setup(s => s.GetAsync(cityName))
            .ReturnsAsync(weatherData);

        _mockAirQualityService
            .Setup(s => s.GetAsync(weatherData.Coordinates.Latitude, weatherData.Coordinates.Longitude))
            .ReturnsAsync((AirQuality?)null);

        // Act
        var result = await _cityInfoService.GetAsync(cityName);

        // Assert
        Assert.Null(result);
        _mockWeatherService.Verify(s => s.GetAsync(cityName), Times.Once);
        _mockAirQualityService.Verify(
            s => s.GetAsync(weatherData.Coordinates.Latitude, weatherData.Coordinates.Longitude),
            Times.Once);
    }
}