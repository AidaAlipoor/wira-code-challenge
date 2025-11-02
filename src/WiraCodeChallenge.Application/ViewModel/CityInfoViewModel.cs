namespace WiraCodeChallenge.Application.DTOs;

public class CityInfoViewModel
{
    public string CityName { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
    public int AirQualityIndex { get; set; }
    public Dictionary<string, double> MajorPollutants { get; set; } = new();
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
