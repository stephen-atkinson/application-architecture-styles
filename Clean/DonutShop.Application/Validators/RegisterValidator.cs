using DonutShop.Application.Models.SignUp;
using FluentValidation;

namespace DonutShop.Application.Validators;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        RuleFor(c => c.Username).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.ReTypePassword).Matches(c => c.Password);
    }
}