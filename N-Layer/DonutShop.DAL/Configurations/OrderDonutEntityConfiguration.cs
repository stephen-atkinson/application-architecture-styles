using DonutShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DonutShop.DAL.Configurations;

public class OrderDonutEntityConfiguration : IEntityTypeConfiguration<OrderDonut>
{
    public void Configure(EntityTypeBuilder<OrderDonut> builder)
    {
        builder.ToTable("OrderDonuts");
        
        builder.HasKey(od => od.Id);

        builder.Property(od => od.UnitPrice).HasPrecision(18, 2);
    }
}