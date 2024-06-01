using Microsoft.EntityFrameworkCore;

namespace DonutShop.Api.Shared.Database.Configurations;

public class DonutShopModelBuilderConfiguration : IConfigureModelBuilder<DonutShopDbContext>
{
    public void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}