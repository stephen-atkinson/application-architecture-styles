using FluentValidation;

namespace DonutShop.Api.Features.Orders.Invoices.GetInvoice;

public class GetInvoiceValidator : AbstractValidator<GetInvoiceQuery>
{
    public GetInvoiceValidator()
    {
        RuleFor(q => q.UserId).NotEmpty();
        RuleFor(q => q.OrderId).GreaterThan(0);
    }
}