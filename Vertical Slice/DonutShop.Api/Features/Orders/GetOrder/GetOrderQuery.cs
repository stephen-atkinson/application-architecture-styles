using MediatR;

namespace DonutShop.Api.Features.Orders.GetOrder;

public class GetOrderQuery : IRequest<OrderDto?>
{
    public string UserId { get; set; }
    public int Id { get; set; }
}