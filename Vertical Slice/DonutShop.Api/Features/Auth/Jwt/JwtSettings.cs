namespace DonutShop.Api.Features.Auth.Jwt;

public class JwtSettings
{
    public string Audience { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string SigningKey { get; set; } = null!;
    public TimeSpan ExpiresIn { get; set; }
}