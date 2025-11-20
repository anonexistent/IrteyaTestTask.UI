using System;

namespace IrteyaTestTask.UI.Domain.Models;

public class WeatherForecast
{
    public DateOnly Date { get; init; }
    public int TemperatureC { get; init; }
    public string Summary { get; init; } = string.Empty;
}