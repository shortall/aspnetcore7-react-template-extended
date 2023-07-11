using Microsoft.EntityFrameworkCore;
using TemplateApp.Data.EF.Context;
using TemplateApp.Data.EF.Exceptions;
using TemplateApp.Data.EF.Repository;
using TemplateApp.Domain.Contract;
using TemplateApp.Domain.Model;

namespace TemplateApp.Data.EF.UnitOfWork
{
    /// <summary>
    /// An Entity Framework implementation of <see cref="IUnitOfWork"/>
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DashboardDBContext _ctx;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="ctx">An injected DB context</param>
        public UnitOfWork(DashboardDBContext ctx)
        {
            _ctx = ctx;
            WeatherForecastRepository = new Repository<WeatherForecast>(ctx);
        }

        /// <summary>
        /// Service Repositories
        /// </summary>
        public IRepository<WeatherForecast> WeatherForecastRepository { get; private set; }

        /// <summary>
        /// Save pending changes
        /// </summary>
        public void Commit()
        {
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Calls a stored procedure
        /// </summary>
        /// <param name="procName">The procedure name</param>
        /// <param name="parameters">A collection of parameters</param>
        public void CallStoredProcedure(string procName, params object[] parameters)
        {
            try
            {
                _ctx.Database.ExecuteSqlRaw(procName, parameters);
            }
            catch (Exception e)
            {
                throw new StoredProcedureException(procName, e);
            }
        }
    }
}
