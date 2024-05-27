using DonutShop.Application;
using DonutShop.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DonutShop.Infrastructure.Database.Configurations;

public class DonutShopModelBuilderConfiguration : IConfigureModelBuilder<DonutShopDbContext>
{
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}