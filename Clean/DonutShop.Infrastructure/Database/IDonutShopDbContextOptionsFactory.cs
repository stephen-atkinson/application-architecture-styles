using DonutShop.Application;
using Microsoft.EntityFrameworkCore;

namespace DonutShop.Infrastructure.Database;

public interface IDonutShopDbContextOptionsFactory
{
    public DbContextOptions<DonutShopDbContext> Create();
}