using MediatR;

namespace DonutShop.Application.Models.GetOrder;

public class GetOrderQuery : IRequest<OrderDto?>
{
    public string UserId { get; set; }
    public int Id { get; set; }
}