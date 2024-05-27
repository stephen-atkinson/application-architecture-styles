namespace DonutShop.BLL.Models.CreateOrder;

public class CreateOrderRequest
{
    public IReadOnlyCollection<CreateOrderDonut> Donuts { get; set; }
}