using System.Linq.Expressions;
using Tamirci.Repository.Contracts.MongoDB;

namespace Tamirci.Repositories.MongoDB;

public abstract class MongoDbRepositoryBase<T> : RepositoryBase<T>, IMongoDbRepositoryBase<T> where T : class
{
    public override Task Create(T entity)
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

    public virtual Task<T> FindById<TypeOfId>(TypeOfId id)
    {
        throw new NotImplementedException();
    }

    public virtual void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
