using Microsoft.AspNetCore.Identity;

namespace DonutShop.Api.Features.Auth;

public interface IAccessTokenGenerator
{
    string Create(IdentityUser user);
}