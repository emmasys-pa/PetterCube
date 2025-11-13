namespace WeatherForecast.Models;

public record WeatherForecastModel(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)Math.Floor(TemperatureC / 0.5556);
}
