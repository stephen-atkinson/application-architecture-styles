using FluentValidation;

namespace DonutShop.Api.Features.Auth.Register;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        RuleFor(c => c.Username).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.ReTypePassword).Matches(c => c.Password);
    }
}