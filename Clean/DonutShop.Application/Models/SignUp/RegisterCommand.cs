using MediatR;

namespace DonutShop.Application.Models.SignUp;

public class RegisterCommand : IRequest<Unit>
{
    /// <example>joe.bloggs</example>
    public string Username { get; set; }
    
    /// <example>Joe123!</example>
    public string Password { get; set; }
    
    /// <example>Joe123!</example>
    public string ReTypePassword { get; set; }
}