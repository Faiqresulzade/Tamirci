using Tamirci.Repository.Contracts.HttpContextCache;

namespace Tamirci.Repository.Contracts;

public interface IRepositoryManager<T>
{
    public IHttpContextCacheRepository<T> HttpContextCacheRepository { get; }
}
