using Microsoft.AspNetCore.Identity;
using ServicesRegisterPlugin.Atributes;
using System.IdentityModel.Tokens.Jwt;
using Tamirci.Entities;
using Tamirci.Services.Constants;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;

namespace Tamirci.Services.Buisness;

[Scoped(nameof(ITokenManager))]
public class TokenManager : ITokenManager
{
    private readonly IServiceManager _serviceManager;
    public TokenManager(IServiceManager serviceManager) => _serviceManager = serviceManager;

    public async Task UpdateUserTokenInfo(Craftsman user, JwtSecurityToken token, string refreshToken, string refreshTokenValidityInDays)
    {
        _ = int.TryParse(refreshTokenValidityInDays, out int refreshTokenValidityInDaysInt);

        user.RefreshToken.Token = refreshToken;
        user.RefreshToken.ExpiryTime = DateTime.UtcNow.AddDays(refreshTokenValidityInDaysInt);

        await _serviceManager.UserManager.UpdateAsync(user);
        await _serviceManager.UserManager.UpdateSecurityStampAsync(user);
        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        await _serviceManager.UserManager.SetAuthenticationTokenAsync(user, ConstData.LOGIN_PROVIDER, ConstData.TOKEN_NAME, tokenValue);

    }
}