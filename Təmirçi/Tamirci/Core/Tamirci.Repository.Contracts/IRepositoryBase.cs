using System.Linq.Expressions;

namespace Tamirci.Repository.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task<T> FindById<TypeOfId>(TypeOfId id);
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}