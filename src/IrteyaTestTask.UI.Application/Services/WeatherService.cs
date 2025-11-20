using IrteyaTestTask.UI.Domain.Models;
using IrteyaTestTask.UI.Infrastructure.WeatherRepositories;
using IrteyaTestTask.UI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IrteyaTestTask.UI.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherRepository _repository;

    public WeatherService(IWeatherRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<WeatherForecast>> GetForecastAsync() =>
        _repository.GetForecastAsync();
}
