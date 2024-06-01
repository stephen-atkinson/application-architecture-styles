using MediatR;

namespace DonutShop.Api.Features.Orders.CreateOrder;

public class CreateOrderCommand : IRequest<EntityDto>
{
    public string UserId { get; set; }
    
    public CreateOrderRequest Request { get; set; }
}