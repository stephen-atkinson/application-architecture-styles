using DonutShop.Api.Features.Orders.CreateOrder;
using FluentValidation;

namespace DonutShop.Api.Features.Auth.Login;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(co => co.UserId).NotEmpty();
        RuleFor(co => co.Request).NotNull();
        RuleFor(co => co.Request.Donuts).NotEmpty();
    }
}