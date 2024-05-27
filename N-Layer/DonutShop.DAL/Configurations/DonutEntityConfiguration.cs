using DonutShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DonutShop.DAL.Configurations;

public class DonutEntityConfiguration : IEntityTypeConfiguration<Donut>
{
    public void Configure(EntityTypeBuilder<Donut> builder)
    {
        builder.ToTable("Donuts");
        
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).IsRequired();
        builder.Property(d => d.Price).HasPrecision(18, 2);

        builder.HasMany(d => d.DonutOrders).WithOne(o => o.Donut);
    }
}