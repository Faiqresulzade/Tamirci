using Microsoft.AspNetCore.Identity;
using System.Data;
using Tamirci.Entities;

namespace Tamirci.Services.Factories;

public class UserFactory
{
    private readonly UserManager<Craftsman> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserFactory(UserManager<Craftsman> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<Craftsman> Create(RegisterCommandRequest request)
    {
        Craftsman user = request;

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
            await CreateRole(user, _userManager, _roleManager, "user");

        return user;
    }

    public async Task CreateRole(Craftsman user, UserManager<Craftsman> userManager, RoleManager<IdentityRole> roleManager, string userRole)
    {
        if (!await roleManager.RoleExistsAsync(userRole))
            await roleManager.CreateAsync(new ()
            {
                Name = userRole,
                NormalizedName = userRole.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });

        await userManager.AddToRoleAsync(user, userRole);
    }
}
