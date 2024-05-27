using DonutShop.DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DonutShop.DAL.Configurations;

public class DonutShopModelBuilderConfiguration : IConfigureModelBuilder<DonutShopDbContext>
{
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}