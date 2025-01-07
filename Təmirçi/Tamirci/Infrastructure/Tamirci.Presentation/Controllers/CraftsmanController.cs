using Microsoft.AspNetCore.Mvc;
using Tamirci.Application.DTOs;
using Tamirci.Services.Contracts;

namespace Tamirci.Presentation.Controllers;

[Route("api/[controller]/[action]"), ApiController]
public class CraftsmanController : BaseController
{
    public CraftsmanController(IServiceManager serviceManager) : base(serviceManager) { }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] CraftsmanRegisterDto request)
    {
      
        await _serviceManager.CraftsmanService.RegisterAsync(request);
        return Created();
    }
}
