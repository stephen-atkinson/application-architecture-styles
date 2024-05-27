using DonutShop.Application;
using DonutShop.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DonutShop.Infrastructure.Database;

// public class DonutShopDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DonutShopDbContext>
// {
//     public DonutShopDbContext CreateDbContext(string[] args)
//     {
//         var options = new DbContextOptionsBuilder<DonutShopDbContext>()
//             .UseSqlite(c => c.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
//             .Options;
//
//         var dbContext = new DonutShopDbContext(options, new DonutShopModelBuilderConfiguration());
//
//         return dbContext;
//     }
// }