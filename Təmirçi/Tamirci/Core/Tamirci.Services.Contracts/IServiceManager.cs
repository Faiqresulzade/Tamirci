using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Tamirci.Entities;
using Tamirci.Repository.Contracts.HttpContextCache;
using Tamirci.Services.Contracts.Buisness;
using Tamirci.Services.Contracts.Factories;

namespace Tamirci.Services.Contracts;

public interface IServiceManager
{
    public ITokenManager TokenManager { get; }
    public ITokenService TokenService { get; }
    public ICraftsmanFactory UserFactory { get; }
    public ICraftsmanService CraftsmanService { get; }
    public UserManager<Craftsman> UserManager { get; }
    public IHttpContextAccessor HttpContextAccessor { get; }

    IHttpContextCacheRepository<T> Get<T>() where T : class;
}
