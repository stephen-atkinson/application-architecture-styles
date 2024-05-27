using MediatR;

namespace DonutShop.BLL.Models.GetOrder;

public class GetOrderQuery : IRequest<OrderDto?>
{
    public string UserId { get; set; }
    public int Id { get; set; }
}