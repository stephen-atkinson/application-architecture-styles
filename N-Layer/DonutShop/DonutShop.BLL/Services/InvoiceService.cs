using DonutShop.BLL.Contracts;
using DonutShop.BLL.Models.Invoice;
using DonutShop.DAL.Entities;

namespace DonutShop.BLL.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceGenerator _invoiceGenerator;
    private readonly IFileService _fileService;

    public InvoiceService(IInvoiceGenerator invoiceGenerator, IFileService fileService)
    {
        _invoiceGenerator = invoiceGenerator;
        _fileService = fileService;
    }
    
    public Task CreateAsync(Order order, CancellationToken cancellationToken)
    {
        var invoice = _invoiceGenerator.Create(order);

        return _fileService.CreateAsync(GetPath(order.Id), invoice, cancellationToken);
    }

    public async Task<OrderInvoice> GetAsync(int orderId, CancellationToken cancellationToken)
    {
        var stream = await _fileService.OpenReadAsync(GetPath(orderId), cancellationToken);

        var invoice = new OrderInvoice
        {
            Stream = stream,
            FileExtension = _invoiceGenerator.FileExtension,
            MimeType = _invoiceGenerator.MimeType
        };

        return invoice;
    }

    private string GetPath(int orderId) => $"Invoices/{orderId}{_invoiceGenerator.FileExtension}";
}