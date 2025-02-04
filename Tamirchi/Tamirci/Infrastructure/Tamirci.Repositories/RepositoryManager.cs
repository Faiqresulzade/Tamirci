using Microsoft.Extensions.DependencyInjection;
using ServicesRegisterPlugin.Atributes;
using Tamirci.Repository.Contracts;
using Tamirci.Repository.Contracts.HttpContextCache;

namespace Tamirci.Repositories;

[Scoped(nameof(IRepositoryManager<T>))]
public class RepositoryManager<T>(IServiceProvider serviceProvider) : IRepositoryManager<T>
{
    private const bool _isThreadSafety = true;

    private readonly Lazy<IHttpContextCacheRepository<T>> _httpContextCacheRepository =
        new Lazy<IHttpContextCacheRepository<T>>(() => serviceProvider.GetRequiredService<IHttpContextCacheRepository<T>>(), _isThreadSafety);

    public IHttpContextCacheRepository<T> HttpContextCacheRepository => _httpContextCacheRepository.Value;
}
