using DonutShop.BLL.Models.GetInvoice;
using FluentValidation;

namespace DonutShop.BLL.Validators;

public class GetInvoiceValidator : AbstractValidator<GetInvoiceQuery>
{
    public GetInvoiceValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
        RuleFor(q => q.OrderId).GreaterThan(0);
    }
}