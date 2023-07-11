using TemplateApp.Domain.Contract;
using TemplateApp.Domain.Model;

namespace TemplateApp.WebApi.GraphQL
{
    public class Query
    {
        public IQueryable<WeatherForecast> GetWeatherForecasts([Service] IUnitOfWork uow) =>
            uow.WeatherForecastRepository.All();
    }
}
