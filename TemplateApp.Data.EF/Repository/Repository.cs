using Microsoft.EntityFrameworkCore;
using TemplateApp.Domain.Contract;
using System.Linq.Expressions;

namespace TemplateApp.Data.EF.Repository
{
    /// <summary>
    /// An Entity Framework implementation of <see cref="IRepository"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public Repository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Get all Entities for the concrete type
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> All()
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        /// Get all Entities including the specified navigation properties
        /// </summary>
        /// <param name="includeProperties">The navigation properties to include in the graph</param>
        /// <returns></returns>
        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            query = IncludePropertiesInQuery(query, includeProperties);
            return query;
        }


        /// <summary>
        /// Find Entities based on the required predicate
        /// </summary>
        /// <param name="predicate">The predicate</param>
        /// <returns></returns>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// Find Entities based on the required predicate
        /// </summary>
        /// <param name="predicate">The predicate</param>
        /// <param name="includeProperties">The navigation properties to include in the graph</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            query = IncludePropertiesInQuery(query, includeProperties);
            return query.Where(predicate);
        }

        /// <summary>
        /// Find first or default Entity
        /// </summary>
        /// <param name="predicate">The search predicate</param>
        /// <returns>The Entity</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Find first Entity matching predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>The Entity</returns>
        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).First();
        }

        /// <summary>
        /// Get Entity by identity
        /// </summary>
        /// <param name="id">The identity</param>
        /// <returns>The Entity</returns>
        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Get Entity by identity including navigation properties
        /// </summary>
        /// <param name="id">The identity</param>
        /// <param name="includeProperties">The navigation properties to include in the graph</param>
        /// <returns>The Entity</returns>
        public TEntity GetByIdIncluding(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Context.Set<TEntity>();
            IncludePropertiesInQuery(query, includeProperties);
            return query.Find(id);
        }

        /// <summary>
        /// Add Entity to the working Context
        /// </summary>
        /// <param name="entity">The Entity</param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Remove Entity to the working Context
        /// </summary>
        /// <param name="entity">The Entity</param>
        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        private IQueryable<TEntity> IncludePropertiesInQuery(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
}
