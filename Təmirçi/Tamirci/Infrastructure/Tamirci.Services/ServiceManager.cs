using Microsoft.Extensions.DependencyInjection;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;

namespace Tamirci.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICraftsmanService> _craftsmanService;

    public ServiceManager(Lazy<IServiceProvider> serviceProvider)
    {
        _craftsmanService = new Lazy<ICraftsmanService>(
            () => serviceProvider.Value.GetRequiredService<ICraftsmanService>());
    }

    public ICraftsmanService CraftsmanService => _craftsmanService.Value;
}
