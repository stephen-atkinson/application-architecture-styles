using DonutShop.DAL.Contracts;
using DonutShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace DonutShop.DAL.Factories;

public class DonutShopDbContextOptionsFactory : IDonutShopDbContextOptionsFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DonutShopDbContextOptionsFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public DbContextOptions<DonutShopDbContext> Create()
    {
        var hostEnvironment = _serviceProvider.GetRequiredService<IHostEnvironment>();
        var dbOptions = _serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>();

        var dbPath = Path.Join(hostEnvironment.ContentRootPath, dbOptions.Value.DatabaseName);
        
        var builder = new DbContextOptionsBuilder<DonutShopDbContext>()
            .UseApplicationServiceProvider(_serviceProvider)
            .UseSqlite($"Data Source={dbPath}", c => c.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

        return builder.Options;
    }

}