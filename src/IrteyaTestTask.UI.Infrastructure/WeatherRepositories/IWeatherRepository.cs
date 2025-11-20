using IrteyaTestTask.UI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IrteyaTestTask.UI.Infrastructure.WeatherRepositories;

public interface IWeatherRepository
{
    Task<IReadOnlyList<WeatherForecast>> GetForecastAsync();
}
