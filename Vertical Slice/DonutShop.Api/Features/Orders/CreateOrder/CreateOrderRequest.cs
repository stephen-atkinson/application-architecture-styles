namespace DonutShop.Api.Features.Orders.CreateOrder;

public class CreateOrderRequest
{
    public IReadOnlyCollection<CreateOrderDonut> Donuts { get; set; }
}