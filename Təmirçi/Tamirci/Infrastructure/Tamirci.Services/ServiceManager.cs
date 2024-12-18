using Microsoft.Extensions.DependencyInjection;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;
using Tamirci.Services.Contracts.Factories;
using ServicesRegisterPlugin.Atributes;
using Microsoft.AspNetCore.Identity;
using Tamirci.Entities;
using Microsoft.AspNetCore.Http;
using Tamirci.Repository.Contracts.HttpContextCache;
using System;

namespace Tamirci.Services;

[Scoped(nameof(IServiceManager))]
public class ServiceManager : IServiceManager
{
    private const bool _isThreadSafety = true;

    private readonly Lazy<UserManager<Craftsman>> _userManager;
    private readonly Lazy<ICraftsmanService> _craftsmanService;
    private readonly Lazy<ICraftsmanFactory> _craftsmanFactory;
    private readonly Lazy<ITokenService> _tokenService;
    private readonly Lazy<ITokenManager> _tokenManager;
    private readonly Lazy<IHttpContextAccessor> _httpContextAccessor;
    private readonly IServiceProvider _serviceProvider;


    public ServiceManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _craftsmanService = new Lazy<ICraftsmanService>(
            () => serviceProvider.GetRequiredService<ICraftsmanService>(), _isThreadSafety);
        _craftsmanFactory = new Lazy<ICraftsmanFactory>(() => serviceProvider.GetRequiredService<ICraftsmanFactory>(), _isThreadSafety);
        _tokenService = new Lazy<ITokenService>(() => serviceProvider.GetRequiredService<ITokenService>(), _isThreadSafety);
        _tokenManager = new Lazy<ITokenManager>(() => serviceProvider.GetRequiredService<ITokenManager>(), _isThreadSafety);
        _userManager = new Lazy<UserManager<Craftsman>>(() => serviceProvider.GetRequiredService<UserManager<Craftsman>>(), _isThreadSafety);
        _httpContextAccessor = new Lazy<IHttpContextAccessor>(() => serviceProvider.GetRequiredService<IHttpContextAccessor>(), _isThreadSafety);
    }

    public ITokenManager TokenManager => _tokenManager.Value;
    public ITokenService TokenService => _tokenService.Value;
    public UserManager<Craftsman> UserManager => _userManager.Value;
    public ICraftsmanFactory UserFactory => _craftsmanFactory.Value;
    public ICraftsmanService CraftsmanService => _craftsmanService.Value;
    public IHttpContextAccessor HttpContextAccessor => _httpContextAccessor.Value;

    public IHttpContextCacheRepository<T> Get<T>() where T : class
      => new Lazy<IHttpContextCacheRepository<T>>(()
      => _serviceProvider.GetRequiredService<IHttpContextCacheRepository<T>>(), _isThreadSafety).Value;

}
