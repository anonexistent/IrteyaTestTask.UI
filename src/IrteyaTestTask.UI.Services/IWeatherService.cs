using IrteyaTestTask.UI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IrteyaTestTask.UI.Services;

public interface IWeatherService
{
    Task<IReadOnlyList<WeatherForecast>> GetForecastAsync();
}
