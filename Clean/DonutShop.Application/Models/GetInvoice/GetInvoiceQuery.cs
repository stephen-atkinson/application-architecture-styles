using DonutShop.Application.Models.Invoice;
using MediatR;

namespace DonutShop.Application.Models.GetInvoice;

public class GetInvoiceQuery : IRequest<OrderInvoice?>
{
    public string UserId { get; set; }
    public int OrderId { get; set; }
}