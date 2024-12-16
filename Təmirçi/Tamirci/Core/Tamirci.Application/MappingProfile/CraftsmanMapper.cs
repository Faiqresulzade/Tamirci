using Tamirci.Application.DTOs;
using Tamirci.Entities;

namespace Tamirci.Application.MappingProfile;

public static class CraftsmanMapper
{
    public static Craftsman MapToCraftsman(this CraftsmanRegisterDto request)
    {
        return new()
        {
            Name = request.Name,
            Surname = request.Surname,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Location = request.Location,
            UserName=request.Email,
        };
    }
}
