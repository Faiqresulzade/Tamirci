using System.Linq.Expressions;
using Tamirci.Repository.Contracts.MongoDB;

namespace Tamirci.Repositories.MongoDB;

public abstract class MongoDbRepositoryBase<T> : RepositoryBase<T>, IMongoDbRepositoryBase<T> where T : class
{
    public override Task Create(T entity)
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

    public override Task<T> FindById<TypeOfId>(TypeOfId id)
    {
        throw new NotImplementedException();
    }

    public override void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
