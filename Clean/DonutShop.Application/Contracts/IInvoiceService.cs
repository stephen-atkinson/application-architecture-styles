using DonutShop.Application.Models.Invoice;
using DonutShop.Domain.Models;

namespace DonutShop.Application.Contracts;

public interface IInvoiceService
{
    Task CreateAsync(Order order, CancellationToken cancellationToken);

    Task<OrderInvoice> GetAsync(int orderId, CancellationToken cancellationToken);
}