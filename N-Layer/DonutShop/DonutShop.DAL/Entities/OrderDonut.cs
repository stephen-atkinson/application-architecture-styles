namespace DonutShop.DAL.Entities;

public class OrderDonut
{
    public int Id { get; set; }
    public required decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    public Donut Donut { get; set; }
    public Order Order { get; set; }
}