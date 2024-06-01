namespace DonutShop.Api.Features.Orders.Invoices;

public record OrderInvoice
{
    public Stream Stream { get; set; }
    public string MimeType { get; set; }
    public string FileExtension { get; set; }
}