using TemplateApp.Domain.Model;

namespace TemplateApp.Domain.Contract
{
    public interface IUnitOfWork
    {
        IRepository<WeatherForecast> WeatherForecastRepository { get; }

        void Commit();
        void CallStoredProcedure(string procName, params object[] parameters);
    }
}
