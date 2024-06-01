using DonutShop.Api.Shared.Database.Entities;

namespace DonutShop.Api.Features.Orders.Invoices;

public interface IInvoiceService
{
    Task CreateAsync(Order order, CancellationToken cancellationToken);

    Task<OrderInvoice> GetAsync(int orderId, CancellationToken cancellationToken);
}