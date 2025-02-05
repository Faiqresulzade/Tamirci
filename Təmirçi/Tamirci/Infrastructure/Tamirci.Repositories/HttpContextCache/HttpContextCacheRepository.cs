using Microsoft.AspNetCore.Http;

namespace Tamirci.Repositories.HttpContextCache;

public class HttpContextCacheRepository<T> : RepositoryBase<T> where T : class
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextCacheRepository(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;
    public override Task Create(T entity)
    {
        _httpContextAccessor.HttpContext.Items[typeof(T).Name] = entity;
        return Task.CompletedTask;
    }

    public T? GetData() => _httpContextAccessor.HttpContext.Items[typeof(T).Name] as T;
}
