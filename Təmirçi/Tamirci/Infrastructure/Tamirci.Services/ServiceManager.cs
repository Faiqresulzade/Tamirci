using Microsoft.Extensions.DependencyInjection;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;

namespace Tamirci.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICraftsmanService> _craftsmanService;
    private readonly Lazy<IProductService> _productService;

    public ServiceManager(Lazy<IServiceProvider> serviceProvider)
    {
        _craftsmanService = new Lazy<ICraftsmanService>(
            () => serviceProvider.Value.GetRequiredService<ICraftsmanService>());
        _productService = new Lazy<IProductService>(() => serviceProvider.Value.GetRequiredService<IProductService>());
    }

    public ICraftsmanService CraftsmanService => _craftsmanService.Value;
    public IProductService ProductService => _productService.Value;
}
