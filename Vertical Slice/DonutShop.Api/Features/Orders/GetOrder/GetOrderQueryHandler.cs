using DonutShop.Api.Shared.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DonutShop.Api.Features.Orders.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto?>
{
    private readonly DonutShopDbContext _donutShopDbContext;

    public GetOrderQueryHandler(DonutShopDbContext donutShopDbContext)
    {
        _donutShopDbContext = donutShopDbContext;
    }
    
    public async Task<OrderDto?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _donutShopDbContext.Orders
            .Include(o => o.OrderDonuts)
            .ThenInclude(od => od.Donut)
            .FirstOrDefaultAsync(o => o.Id == request.Id && o.UserId == request.UserId, cancellationToken);

        if (order == null)
        {
            return null;
        }

        var dto = new OrderDto
        {
            Id = order.Id,
            Price = order.OrderDonuts.Sum(od => od.UnitPrice * od.Quantity),
            Donuts = order.OrderDonuts.Select(od => new OrderDonutDto
            {
                Name = od.Donut.Name,
                Quantity = od.Quantity,
                UnitPrice = od.UnitPrice,
            }).ToArray(),
        };

        return dto;
    }
}