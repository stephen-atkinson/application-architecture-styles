using DonutShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DonutShop.DAL.Configurations;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        
        builder.HasKey(o => o.Id);

        builder.Property(o => o.UserId).IsRequired();
        
        builder.HasMany(o => o.OrderDonuts).WithOne(od => od.Order);
    }
}