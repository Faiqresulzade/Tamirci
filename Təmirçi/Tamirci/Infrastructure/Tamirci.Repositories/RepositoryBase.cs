using System.Linq.Expressions;
using Tamirci.Repository.Contracts;

namespace Tamirci.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public abstract Task Create(T entity);

    public abstract void Delete(T entity);

    public abstract IQueryable<T> FindAll();

    public abstract IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

    public abstract Task<T> FindById<TypeOfId>(TypeOfId id);

    public abstract void Update(T entity);
}
