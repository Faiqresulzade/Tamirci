using System.Linq.Expressions;
using Tamirci.Repository.Contracts.MSSQLDB;

namespace Tamirci.Repositories.MSSQLDB;

public abstract class MsSqlDBRepositoryBase<T> : RepositoryBase<T>, IMsSqlDBRepositoryBase<T> where T : class
{
    public async override Task Create(T entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public override IQueryable<T> FindAll()
    {
        throw new NotImplementedException();
    }

    public override IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public async override Task<T> FindById<TypeOfId>(TypeOfId id)
    {
        throw new NotImplementedException();
    }

    public override void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
