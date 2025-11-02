namespace WiraCodeChallenge.Domain.Entities;

public class Weather
{
    public string CityName { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
    public Coordinates Coordinates { get; set; } = new();
}

public class Coordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
