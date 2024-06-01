using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DonutShop.Api.Features.Auth.Jwt;

public class JwtGenerator : IAccessTokenGenerator
{
    private readonly IOptions<JwtSettings> _jwtOptions;
    private readonly TimeProvider _timeProvider;

    public JwtGenerator(IOptions<JwtSettings> jwtOptions, TimeProvider timeProvider)
    {
        _jwtOptions = jwtOptions;
        _timeProvider = timeProvider;
    }

    public string Create(IdentityUser user)
    {
        var jwtSettings = _jwtOptions.Value;
        var utcNow = _timeProvider.GetUtcNow().DateTime;
        var signingKey = jwtSettings.GetSigningKey();
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);
        
        var claims = new Dictionary<string, object>
        {
            [ClaimTypes.Name] = user.UserName!,
            [ClaimTypes.Sid] = user.Id
        };
        
        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = jwtSettings.Issuer,
            Audience = jwtSettings.Audience,
            Claims = claims,
            IssuedAt = utcNow,
            NotBefore = utcNow,
            Expires = utcNow.Add(jwtSettings.ExpiresIn),
            SigningCredentials = signingCredentials
        };

        var handler = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler
        {
            SetDefaultTimesOnTokenCreation = false
        };
        
        var tokenString = handler.CreateToken(descriptor);
        
        return tokenString;
    }
}