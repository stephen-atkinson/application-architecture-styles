using DonutShop.BLL.Contracts;
using DonutShop.BLL.Models;
using DonutShop.BLL.Models.CreateOrder;
using DonutShop.DAL;
using DonutShop.DAL.Entities;
using MediatR;

namespace DonutShop.BLL.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, EntityDto>
{
    private readonly DonutShopDbContext _dbContext;
    private readonly IInvoiceService _invoiceService;

    public CreateOrderCommandHandler(DonutShopDbContext dbContext, IInvoiceService invoiceService)
    {
        _dbContext = dbContext;
        _invoiceService = invoiceService;
    }
    
    public async Task<EntityDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderDonuts = new List<OrderDonut>();

        foreach (var orderDonut in request.Request.Donuts)
        {
            var donut = await _dbContext.Donuts.FindAsync([orderDonut.Id], cancellationToken);
            
            orderDonuts.Add(new OrderDonut
            {
                UnitPrice = donut.Price,
                Quantity = orderDonut.Quantity,
                Donut = donut
            });
        }

        var order = new Order
        {
            UserId = request.UserId,
            OrderDonuts = orderDonuts,
        };

        await _dbContext.Orders.AddAsync(order, CancellationToken.None);

        await _dbContext.SaveChangesAsync(CancellationToken.None);

        await _invoiceService.CreateAsync(order, CancellationToken.None);

        var dto = new EntityDto { Id = order.Id };

        return dto;
    }
}