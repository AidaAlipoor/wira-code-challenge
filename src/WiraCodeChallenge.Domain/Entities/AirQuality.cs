namespace WiraCodeChallenge.Domain.Entities;

public class AirQuality
{
    public int AirQualityIndex { get; set; }
    public Dictionary<string, double> Pollutants { get; set; } = new();
    public Coordinates Coordinates { get; set; } = new();
}
