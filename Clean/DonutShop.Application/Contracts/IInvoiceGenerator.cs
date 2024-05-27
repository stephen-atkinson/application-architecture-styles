using DonutShop.Domain.Models;

namespace DonutShop.Application.Contracts;

public interface IInvoiceGenerator
{
    string FileExtension { get; }
    string MimeType { get; }
    byte[] Create(Order order);
}