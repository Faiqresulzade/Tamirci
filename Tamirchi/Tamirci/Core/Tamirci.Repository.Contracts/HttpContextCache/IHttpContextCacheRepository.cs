namespace Tamirci.Repository.Contracts.HttpContextCache;

public interface IHttpContextCacheRepository<T> : IRepositoryBase<T>
{
    T GetData();
}
