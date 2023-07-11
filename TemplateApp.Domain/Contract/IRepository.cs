using System.Linq.Expressions;

namespace TemplateApp.Domain.Contract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        TEntity GetByIdIncluding(int id, params Expression<Func<TEntity, object>>[] includeProperties);

        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
