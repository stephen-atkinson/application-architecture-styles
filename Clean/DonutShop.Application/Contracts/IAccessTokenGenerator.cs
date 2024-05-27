using Microsoft.AspNetCore.Identity;

namespace DonutShop.Application.Contracts;

public interface IAccessTokenGenerator
{
    string Create(IdentityUser user);
}