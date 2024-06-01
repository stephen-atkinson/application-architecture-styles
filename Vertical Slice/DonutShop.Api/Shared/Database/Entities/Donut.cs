namespace DonutShop.Api.Shared.Database.Entities;

public class Donut
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public ICollection<OrderDonut> DonutOrders { get; set; }
}