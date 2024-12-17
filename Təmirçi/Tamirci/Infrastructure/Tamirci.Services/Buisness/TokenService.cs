using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServicesRegisterPlugin.Atributes;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Tamirci.Entities;
using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;
using Tamirci.Shared.Models;

namespace Tamirci.Services.Buisness;
[Scoped(nameof(ITokenService))]
public class TokenService : ITokenService
{
    private readonly TokenSetting _tokenSettings;
    private readonly IServiceManager _serviceManager;
    public TokenService(IOptions<TokenSetting> options, IServiceManager serviceManager)
    {
        _tokenSettings = options.Value;
        _serviceManager = serviceManager;
    }

    public async Task<JwtSecurityToken> CreateToken(Craftsman user, IList<string> roles)
    {
        var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
            };

        foreach (string role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

        var token = new JwtSecurityToken(
            issuer: _tokenSettings.Issuer,
            audience: _tokenSettings.Audience,
            expires: DateTime.Now.AddMinutes(_tokenSettings.TokenValidityInMunitues),
            claims: claims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        await _serviceManager.UserManager.AddClaimsAsync(user, claims);

        return token;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        TokenValidationParameters tokenValidationParametrs = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret)),
            ValidateLifetime = false,
        };

        JwtSecurityTokenHandler tokenHandler = new();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParametrs, out SecurityToken securityToken);

        if (IsValidToken(securityToken))
            throw new SecurityTokenException("Token tapılmadı");

        return principal;
    }

    private bool IsValidToken(SecurityToken securityToken)
    => securityToken is not JwtSecurityToken jwtSecurityToken ||
       !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
       StringComparison.InvariantCultureIgnoreCase);
}