using Microsoft.AspNetCore.Identity;
using ServicesRegisterPlugin.Atributes;
using Tamirci.Application.DTOs;
using Tamirci.Application.MappingProfile;
using Tamirci.Entities;
using Tamirci.Services.Contracts.Factories;

namespace Tamirci.Services.Factories;
//Abstract Factory
[Scoped(nameof(ICraftsmanFactory))]
public class CraftsmanFactory : ICraftsmanFactory
{
    private readonly UserManager<Craftsman> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public CraftsmanFactory(UserManager<Craftsman> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Craftsman> CreateAsync(CraftsmanRegisterDto request)
    {
        Craftsman craftsman = request.MapToCraftsman();
        IdentityResult result = await _userManager.CreateAsync(craftsman, request.Password);
        if (result.Succeeded)
            await CreateRoleAsync(craftsman, "craftsman");

        return craftsman;
    }

    public async Task<Task> CreateRoleAsync(Craftsman user, string userRole)
    {
        if (!await _roleManager.RoleExistsAsync(userRole))
            await _roleManager.CreateAsync(new()
            {
                Name = userRole,
                NormalizedName = userRole.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });

        return _userManager.AddToRoleAsync(user, userRole);
    }
}
