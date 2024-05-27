using Microsoft.EntityFrameworkCore;

namespace DonutShop.DAL.Contracts;

public interface IDonutShopDbContextOptionsFactory
{
    public DbContextOptions<DonutShopDbContext> Create();
}