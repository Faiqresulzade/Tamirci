using Microsoft.Extensions.DependencyInjection;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;
using Tamirci.Services.Contracts.Factories;
using ServicesRegisterPlugin.Atributes;
using Microsoft.AspNetCore.Identity;
using Tamirci.Entities;

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

    public ServiceManager(IServiceProvider serviceProvider)
    {
        _craftsmanService = new Lazy<ICraftsmanService>(
            () => serviceProvider.GetRequiredService<ICraftsmanService>(), _isThreadSafety);
        _craftsmanFactory = new Lazy<ICraftsmanFactory>(() => serviceProvider.GetRequiredService<ICraftsmanFactory>(), _isThreadSafety);
        _tokenService = new Lazy<ITokenService>(() => serviceProvider.GetRequiredService<ITokenService>(), _isThreadSafety);
        _tokenManager = new Lazy<ITokenManager>(() => serviceProvider.GetRequiredService<ITokenManager>(), _isThreadSafety);
        _userManager = new Lazy<UserManager<Craftsman>>(() => serviceProvider.GetRequiredService<UserManager<Craftsman>>(), _isThreadSafety);

    }

    public ITokenManager TokenManager => _tokenManager.Value;
    public ITokenService TokenService => _tokenService.Value;
    public ICraftsmanFactory UserFactory => _craftsmanFactory.Value;
    public UserManager<Craftsman> UserManager => _userManager.Value;
    public ICraftsmanService CraftsmanService => _craftsmanService.Value;
}
