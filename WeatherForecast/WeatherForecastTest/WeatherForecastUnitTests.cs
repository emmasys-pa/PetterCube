using FluentAssertions;

namespace WeatherApi.Tests;

public class WeatherForecastUnitTests
{


    [Fact]
    public void WeatherForecast_Record_IsImmutable()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var wf = new WeatherForecast(today, 5, "Cool");
        wf.Date.Should().Be(today);
        wf.TemperatureC.Should().Be(5);
        wf.Summary.Should().Be("Cool");
    }
}