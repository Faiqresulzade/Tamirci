using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ServicesRegisterPlugin.Atributes;
using Tamirci.Entities;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;
using Tamirci.Services.Contracts.Factories;

namespace Tamirci.Services;

[Scoped(nameof(IServiceManager))]
public class ServiceManager(IServiceProvider serviceProvider) : IServiceManager
{
    private const bool _isThreadSafety = true;

    private readonly Lazy<UserManager<Craftsman>> _userManager = new Lazy<UserManager<Craftsman>>(()
        => serviceProvider.GetRequiredService<UserManager<Craftsman>>(), _isThreadSafety);
    private readonly Lazy<ICraftsmanService> _craftsmanService = new Lazy<ICraftsmanService>(() 
        => serviceProvider.GetRequiredService<ICraftsmanService>(), _isThreadSafety);
    private readonly Lazy<ICraftsmanFactory> _craftsmanFactory = new Lazy<ICraftsmanFactory>(()
        => serviceProvider.GetRequiredService<ICraftsmanFactory>(), _isThreadSafety);
    private readonly Lazy<ITokenService> _tokenService = new Lazy<ITokenService>(() 
        => serviceProvider.GetRequiredService<ITokenService>(), _isThreadSafety);
    private readonly Lazy<ITokenManager> _tokenManager = new Lazy<ITokenManager>(() 
        => serviceProvider.GetRequiredService<ITokenManager>(), _isThreadSafety);
    private readonly Lazy<IHttpContextAccessor> _httpContextAccessor = new Lazy<IHttpContextAccessor>(()
        => serviceProvider.GetRequiredService<IHttpContextAccessor>(), _isThreadSafety);

    public ITokenManager TokenManager => _tokenManager.Value;
    public ITokenService TokenService => _tokenService.Value;
    public UserManager<Craftsman> UserManager => _userManager.Value;
    public ICraftsmanFactory UserFactory => _craftsmanFactory.Value;
    public ICraftsmanService CraftsmanService => _craftsmanService.Value;
    public IHttpContextAccessor HttpContextAccessor => _httpContextAccessor.Value;
}
