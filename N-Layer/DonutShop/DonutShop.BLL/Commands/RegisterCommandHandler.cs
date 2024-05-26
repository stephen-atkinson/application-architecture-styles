using DonutShop.BLL.Exceptions;
using DonutShop.BLL.Models.SignUp;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DonutShop.BLL.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly AspNetUserManager<IdentityUser> _userManager;

    public RegisterCommandHandler(AspNetUserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);

        if (user != null)
        {
            throw new UserExistsException(request.Username);
        }
        
        user = new IdentityUser { UserName = request.Username };

        var result = await _userManager.CreateAsync(user, request.Password);
        
        if (!result.Succeeded)
        {
            var errors = string.Join(" | ", result.Errors.Select(e => $"Code: {e.Code}. Description: {e.Description}"));

            throw new Exception(errors);
        }
        
        return Unit.Value;
    }
}