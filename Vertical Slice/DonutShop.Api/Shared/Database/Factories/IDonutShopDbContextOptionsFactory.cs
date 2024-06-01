using Microsoft.EntityFrameworkCore;

namespace DonutShop.Api.Shared.Database.Factories;

public interface IDonutShopDbContextOptionsFactory
{
    public DbContextOptions<DonutShopDbContext> Create();
}