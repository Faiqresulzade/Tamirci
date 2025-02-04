using System.IdentityModel.Tokens.Jwt;
using Tamirci.Entities;

namespace Tamirci.Services.Contracts.Buisness
{
    public interface ITokenManager
    {
        Task UpdateUserTokenInfo(Craftsman user, JwtSecurityToken token, string refreshToken, string refreshTokenValidityInDays);
    }
}
