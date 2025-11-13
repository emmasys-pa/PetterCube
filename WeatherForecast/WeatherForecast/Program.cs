var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild",
    "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Kan typisk trigge Roslynator (“kan være const”)
var days = 5;

app.MapGet("/weatherforecast", () =>
    {
        var start = DateTime.Now;

        var forecast = Enumerable
            .Range(1, days)
            .Select(index =>
            {
                var date = DateOnly.FromDateTime(start.AddDays(index));
                var temperatureC = Random.Shared.Next(-20, 55);

                var summaryIndex = Random.Shared.Next(summaries.Length);
                var summary = summaries[summaryIndex];

                return new WeatherForecast(date, temperatureC, summary);
            })
            .ToArray()
            .ToArray();

        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)Math.Floor(TemperatureC / 0.5556);
}
