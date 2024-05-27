using MediatR;

namespace DonutShop.Application.Models.CreateOrder;

public class CreateOrderCommand : IRequest<EntityDto>
{
    public string UserId { get; set; }
    
    public CreateOrderRequest Request { get; set; }
}