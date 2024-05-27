using Microsoft.AspNetCore.Identity;

namespace DonutShop.BLL.Contracts;

public interface IAccessTokenGenerator
{
    string Create(IdentityUser user);
}