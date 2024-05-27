using DonutShop.BLL.Models.Invoice;
using DonutShop.DAL.Entities;

namespace DonutShop.BLL.Contracts;

public interface IInvoiceService
{
    Task CreateAsync(Order order, CancellationToken cancellationToken);

    Task<OrderInvoice> GetAsync(int orderId, CancellationToken cancellationToken);
}