using System.Linq.Expressions;
using Tamirci.Repository.Contracts.MSSQLDB;

namespace Tamirci.Repositories.MSSQLDB;

public abstract class MsSqlDBRepositoryBase<T> : RepositoryBase<T>, IMsSqlDBRepositoryBase<T> where T : class
{
    public override async Task Create(T entity)
    {
        
        throw new NotImplementedException();
    }

    public virtual void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual IQueryable<T> FindAll()
    {
        throw new NotImplementedException();
    }

    public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> FindById<TypeOfId>(TypeOfId id)
    {
        throw new NotImplementedException();
    }

    public virtual void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
