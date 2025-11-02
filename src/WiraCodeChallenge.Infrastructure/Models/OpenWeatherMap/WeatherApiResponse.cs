public class WeatherApiResponse
{
    public string Name { get; set; } = string.Empty;
    public CoordinatesData Coord { get; set; } = new();
    public MainData Main { get; set; } = new();
    public WindData Wind { get; set; } = new();
    public List<WeatherDescription> Weather { get; set; } = new();
}

public class CoordinatesData
{
    public double Lat { get; set; }
    public double Lon { get; set; }
}

public class MainData
{
    public double Temp { get; set; }
    public double Feels_Like { get; set; }
    public double Humidity { get; set; }
}

public class WindData
{
    public double Speed { get; set; }
    public double Deg { get; set; }
}

public class WeatherDescription
{
    public string Main { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}