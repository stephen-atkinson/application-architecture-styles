using DonutShop.DAL.Entities;

namespace DonutShop.BLL.Contracts;

public interface IInvoiceGenerator
{
    string FileExtension { get; }
    string MimeType { get; }
    byte[] Create(Order order);
}