using Tamirci.Application.DTOs;

namespace Tamirci.Services.Contracts.Buisness;

public interface ICraftsmanService
{
    Task RegisterAsync(CraftsmanRegisterDto request);
}
