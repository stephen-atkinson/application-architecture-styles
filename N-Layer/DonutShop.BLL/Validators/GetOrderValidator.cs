using DonutShop.BLL.Models.GetOrder;
using FluentValidation;

namespace DonutShop.BLL.Validators;

public class GetOrderValidator : AbstractValidator<GetOrderQuery>
{
    public GetOrderValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
        RuleFor(q => q.Id).GreaterThan(0);
    }
}