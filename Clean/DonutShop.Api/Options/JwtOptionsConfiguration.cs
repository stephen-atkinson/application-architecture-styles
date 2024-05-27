using DonutShop.Api.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace DonutShop.Api.Options;

public class JwtOptionsConfiguration : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly IOptionsMonitor<JwtSettings> _settingsMonitor;

    public JwtOptionsConfiguration(IOptionsMonitor<JwtSettings> settingsMonitor)
    {
        _settingsMonitor = settingsMonitor;
    }
    
    public void Configure(JwtBearerOptions options)
    {
        Configure(JwtBearerDefaults.AuthenticationScheme, options);
    }
    
    public void Configure(string? name, JwtBearerOptions options)
    {
        var settings = _settingsMonitor.CurrentValue;

        options.TokenValidationParameters.IssuerSigningKey = settings.GetSigningKey();
        options.TokenValidationParameters.ValidIssuer = settings.Issuer;
        options.TokenValidationParameters.ValidAudience = settings.Audience;
    }
}