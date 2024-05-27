using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DonutShop.Api.Jwt;

public static class JwtSettingsExtensions
{
    public static SymmetricSecurityKey GetSigningKey(this JwtSettings settings) =>
        new(Encoding.UTF8.GetBytes(settings.SigningKey));
}