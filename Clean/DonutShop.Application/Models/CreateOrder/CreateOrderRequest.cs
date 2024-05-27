namespace DonutShop.Application.Models.CreateOrder;

public class CreateOrderRequest
{
    public IReadOnlyCollection<CreateOrderDonut> Donuts { get; set; }
}