using DonutShop.BLL.Contracts;
using DonutShop.BLL.Exceptions;
using DonutShop.BLL.Models.Login;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DonutShop.BLL.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthToken>
{
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    private readonly AspNetUserManager<IdentityUser> _aspNetUserManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginCommandHandler(
        IAccessTokenGenerator accessTokenGenerator,
        AspNetUserManager<IdentityUser> aspNetUserManager,
        SignInManager<IdentityUser> signInManager)
    {
        _accessTokenGenerator = accessTokenGenerator;
        _aspNetUserManager = aspNetUserManager;
        _signInManager = signInManager;
    }
    
    public async Task<AuthToken> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await _aspNetUserManager.FindByNameAsync(command.Username);

        if (user == null)
        {
            throw new LoginFailedException();
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, command.Password, false);

        if (!signInResult.Succeeded)
        {
            throw new LoginFailedException();
        }

        var accessToken = _accessTokenGenerator.Create(user);

        var authToken = new AuthToken
        {
            Value = accessToken
        };

        return authToken;
    }
}