namespace DonutShop.DAL.Entities;

public class Order
{
    public int Id { get; set; }
    public string UserId { get; set; }
    
    public ICollection<OrderDonut> OrderDonuts { get; set; }
}