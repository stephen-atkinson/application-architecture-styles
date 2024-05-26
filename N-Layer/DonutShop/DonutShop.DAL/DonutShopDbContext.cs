using DonutShop.DAL.Contracts;
using DonutShop.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DonutShop.DAL;

public class DonutShopDbContext : IdentityDbContext
{
    private readonly IConfigureModelBuilder<DonutShopDbContext> _configureModelBuilder;

    public DonutShopDbContext(DbContextOptions<DonutShopDbContext> options, IConfigureModelBuilder<DonutShopDbContext> configureModelBuilder) : base(options)
    {
        _configureModelBuilder = configureModelBuilder;
    }
    
    public DbSet<Donut> Donuts => Set<Donut>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDonut> OrderDonuts => Set<OrderDonut>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        _configureModelBuilder.Configure(modelBuilder);
    }
}