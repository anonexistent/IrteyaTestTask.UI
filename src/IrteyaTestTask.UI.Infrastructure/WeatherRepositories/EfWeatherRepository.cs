using IrteyaTestTask.UI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IrteyaTestTask.UI.Infrastructure.WeatherRepositories;

public class EfWeatherRepository : IWeatherRepository
{
    private readonly WeatherDbContext _db;

    public EfWeatherRepository(WeatherDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<WeatherForecast>> GetForecastAsync()
    {
        return await _db.Weather.AsNoTracking().ToListAsync();
    }
}
