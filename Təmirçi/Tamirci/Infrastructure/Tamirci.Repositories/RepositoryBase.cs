using System.Linq.Expressions;
using Tamirci.Repository.Contracts;

namespace Tamirci.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public abstract Task Create(T entity);

}
