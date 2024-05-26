using MediatR;

namespace DonutShop.BLL.Models.Login;

public class LoginCommand : IRequest<AuthToken>
{
    /// <example>joe.bloggs</example>
    public string Username { get; set; }
    
    /// <example>Joe123!</example>
    public string Password { get; set; }
}