namespace DonutShop.Api.Features.Orders.GetOrder;

public class OrderDonutDto
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}