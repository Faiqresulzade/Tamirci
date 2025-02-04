using System.Linq.Expressions;

namespace Tamirci.Repository.Contracts;

public interface IRepositoryBase<T>
{
    Task Create(T entity);
}