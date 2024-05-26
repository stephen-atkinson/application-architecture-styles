using System.Text;
using DonutShop.Web.Models.Settings;
using Microsoft.IdentityModel.Tokens;

namespace DonutShop.Web.Extensions;

public static class JwtSettingsExtensions
{
    public static SymmetricSecurityKey GetSigningKey(this JwtSettings settings) =>
        new(Encoding.UTF8.GetBytes(settings.SigningKey));
}