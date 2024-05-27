using DonutShop.Application.Models.CreateOrder;
using FluentValidation;

namespace DonutShop.Application.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(co => co.UserId).NotEmpty();
        RuleFor(co => co.Request).NotNull();
        RuleFor(co => co.Request.Donuts).NotEmpty();
    }
}