using Tamirci.Application.DTOs;
using Tamirci.Entities;

namespace Tamirci.Services.Contracts.Factories;

public interface ICraftsmanFactory
{
    Task<Task> CreateRoleAsync(Craftsman user, string userRole);
    Task<Craftsman> CreateAsync(CraftsmanRegisterDto request);
}
