using FluentValidation;

namespace DonutShop.Api.Features.Orders.GetOrder;

public class GetOrderValidator : AbstractValidator<GetOrderQuery>
{
    public GetOrderValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
        RuleFor(q => q.Id).GreaterThan(0);
    }
}