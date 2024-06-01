using DonutShop.Api.Shared.Database.Entities;

namespace DonutShop.Api.Features.Orders.Invoices;

public interface IInvoiceGenerator
{
    string FileExtension { get; }
    string MimeType { get; }
    byte[] Create(Order order);
}