using MediatR;

namespace DonutShop.Api.Features.Orders.Invoices.GetInvoice;

public class GetInvoiceQuery : IRequest<OrderInvoice?>
{
    public string UserId { get; set; }
    public int OrderId { get; set; }
}