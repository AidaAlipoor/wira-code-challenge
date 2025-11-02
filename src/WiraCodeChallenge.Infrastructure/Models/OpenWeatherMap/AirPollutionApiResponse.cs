namespace WiraCodeChallenge.Infrastructure.Models.OpenWeatherMap;
public class AirPollutionApiResponse
{
    public CoordinatesData Coord { get; set; } = new();
    public List<AirQualityList> List { get; set; } = new();
}

public class AirQualityList
{
    public int Aqi { get; set; }
    public ComponentsData Components { get; set; } = new();
}

public class ComponentsData
{
    public double Co { get; set; }
    public double No { get; set; }
    public double No2 { get; set; }
    public double O3 { get; set; }
    public double So2 { get; set; }
    public double Pm2_5 { get; set; }
    public double Pm10 { get; set; }
    public double Nh3 { get; set; }
}
