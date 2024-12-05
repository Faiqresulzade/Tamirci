using Microsoft.AspNetCore.Mvc;
using Tamirci.Services.Contracts;

namespace Tamirci.Presentation;

public class BaseController : ControllerBase
{
    private protected readonly IServiceManager _serviceManager;
    public BaseController(IServiceManager serviceManager) => _serviceManager = serviceManager;
}
