using FluentAssertions;

namespace WeatherForecastTest;

public class WeatherForecastUnitTests
{
    [Theory]
    [InlineData(-20, -4)]
    [InlineData(0, 32)]
    [InlineData(10, 49)]
    [InlineData(25, 76)]
    public void TemperatureF_IsCalculatedFromCelsius(int c, int expectedF)
    {
        var wf = new WeatherForecast(DateOnly.FromDateTime(DateTime.UtcNow), c, "Mild");
        _ = wf.TemperatureF.Should().Be(expectedF);
    }

    [Fact]
    public void WeatherForecast_Record_IsImmutable()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var wf = new WeatherForecast(today, 5, "Cool");
        _ = wf.Date.Should().Be(today);
        _ = wf.TemperatureC.Should().Be(5);
        _ = wf.Summary.Should().Be("Cool");
    }
}
