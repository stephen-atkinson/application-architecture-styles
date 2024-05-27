using DonutShop.BLL.Models.Invoice;
using MediatR;

namespace DonutShop.BLL.Models.GetInvoice;

public class GetInvoiceQuery : IRequest<OrderInvoice?>
{
    public string UserId { get; set; }
    public int OrderId { get; set; }
}