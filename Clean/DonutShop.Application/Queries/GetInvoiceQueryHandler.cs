using DonutShop.Application.Contracts;
using DonutShop.Application.Models.GetInvoice;
using DonutShop.Application.Models.Invoice;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DonutShop.Application.Queries;

public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, OrderInvoice?>
{
    private readonly DonutShopDbContext _donutShopDbContext;
    private readonly IInvoiceService _invoiceService;

    public GetInvoiceQueryHandler(DonutShopDbContext donutShopDbContext, IInvoiceService invoiceService)
    {
        _donutShopDbContext = donutShopDbContext;
        _invoiceService = invoiceService;
    }

    public async Task<OrderInvoice?> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        var order = await _donutShopDbContext.Orders
            .FirstOrDefaultAsync(o => o.Id == request.OrderId && o.UserId == request.UserId, cancellationToken);

        if (order == null)
        {
            return null;
        }
        
        var invoice = await _invoiceService.GetAsync(request.OrderId, cancellationToken);

        return invoice;
    }
}