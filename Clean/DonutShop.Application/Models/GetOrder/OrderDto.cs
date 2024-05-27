namespace DonutShop.Application.Models.GetOrder;

public class OrderDto : EntityDto
{
    public decimal Price { get; set; }
    public IReadOnlyCollection<OrderDonutDto> Donuts { get; set; }
}