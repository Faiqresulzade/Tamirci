using Microsoft.AspNetCore.Mvc;
using Tamirci.Services.Contracts;

namespace Tamirci.Presentation.Controllers;

public class CraftsmanController : BaseController
{
    public CraftsmanController(IServiceManager serviceManager) : base(serviceManager) { }

    public async Task<IActionResult> Register()
    {
        _serviceManager.CraftsmanService.RegisterAsync();
    }
}
