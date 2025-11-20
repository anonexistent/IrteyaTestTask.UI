using IrteyaTestTask.UI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrteyaTestTask.UI.Infrastructure.WeatherRepositories;

public class InMemoryWeatherRepository : IWeatherRepository
{
    private readonly IReadOnlyList<WeatherForecast> _data;

    public InMemoryWeatherRepository()
    {
        var rnd = new Random(1234);

        _data = [.. Enumerable.Range(1, 5).Select(i => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(i)),
            TemperatureC = rnd.Next(-20, 35),
            Summary = rnd.Next() % 2 == 0 ? "Sunny" : "Cloudy",
        })];
    }

    public Task<IReadOnlyList<WeatherForecast>> GetForecastAsync() =>
        Task.FromResult(_data);
}