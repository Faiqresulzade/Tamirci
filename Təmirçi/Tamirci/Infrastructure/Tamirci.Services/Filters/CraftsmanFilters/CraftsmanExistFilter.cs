using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tamirci.Application.DTOs;
using Tamirci.Entities;
using Tamirci.Services.Contracts;

namespace Tamirci.Services.Filters.CraftsmanFilters;

public class CraftsmanExistFilter : IAsyncActionFilter
{
    private readonly IServiceManager _serviceManager;
    public CraftsmanExistFilter(IServiceManager serviceManager) => _serviceManager = serviceManager;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var request = context.ActionArguments.Values
            .OfType<CraftsmanRegisterDto>()
            .FirstOrDefault();

        if (request is null)
        {
            context.Result = new BadRequestObjectResult("Invalid request data.");
            return;
        }

        var existingUser = await _serviceManager.UserManager.FindByEmailAsync(request.Email);
        if (existingUser is not null)
        {
            context.Result = new BadRequestObjectResult("Bu email artıq istifadə olunur.");
            return;
        }

        var existingPhoneNumberUser = _serviceManager.UserManager.Users.Any(u => u.PhoneNumber == request.PhoneNumber);

        if (existingPhoneNumberUser)
        {
            context.Result = new BadRequestObjectResult("Bu telefon nömrəsi artıq istifadə olunur.");
            return;
        }
        _serviceManager.Get<Craftsman>();
        await next();
    }
}
