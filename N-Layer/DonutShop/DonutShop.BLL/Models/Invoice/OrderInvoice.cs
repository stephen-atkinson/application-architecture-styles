namespace DonutShop.BLL.Models.Invoice;

public record OrderInvoice
{
    public Stream Stream { get; set; }
    public string MimeType { get; set; }
    public string FileExtension { get; set; }
}