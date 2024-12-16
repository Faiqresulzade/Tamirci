using ServicesRegisterPlugin.Atributes;
using Tamirci.Application.DTOs;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;

namespace Tamirci.Services.Buisness;

[Scoped(nameof(ICraftsmanService))]
public class CraftsmanService : ICraftsmanService
{
    private readonly IServiceManager _serviceManager;
    public CraftsmanService(IServiceManager serviceManager) => _serviceManager = serviceManager;
    public async Task RegisterAsync(CraftsmanRegisterDto request)
    {
        await _serviceManager.UserFactory.CreateAsync(request);
    }
}