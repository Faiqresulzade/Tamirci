using Microsoft.Extensions.DependencyInjection;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;
using Tamirci.Services.Contracts.Factories;
using ServicesRegisterPlugin.Atributes;

namespace Tamirci.Services;

[Scoped(nameof(IServiceManager))]
public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICraftsmanService> _craftsmanService;
    private readonly Lazy<ICraftsmanFactory> _craftsmanFactory;

    public ServiceManager(IServiceProvider serviceProvider)
    {
        _craftsmanService = new Lazy<ICraftsmanService>(
            () => serviceProvider.GetRequiredService<ICraftsmanService>());
        _craftsmanFactory = new Lazy<ICraftsmanFactory>(() => serviceProvider.GetRequiredService<ICraftsmanFactory>());
    }

    public ICraftsmanService CraftsmanService => _craftsmanService.Value;
    public ICraftsmanFactory UserFactory => _craftsmanFactory.Value;
}
