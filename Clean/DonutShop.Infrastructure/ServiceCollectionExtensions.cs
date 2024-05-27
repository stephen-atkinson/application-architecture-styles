using DonutShop.Application;
using DonutShop.Application.Contracts;
using DonutShop.Infrastructure.Database;
using DonutShop.Infrastructure.Database.Configurations;
using DonutShop.Infrastructure.Files;
using DonutShop.Infrastructure.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DonutShop.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<DatabaseSettings>(configuration.GetRequiredSection("Database"));
        
        serviceCollection.AddSingleton<IConfigureModelBuilder<DonutShopDbContext>, DonutShopModelBuilderConfiguration>();
        serviceCollection.AddSingleton<IDonutShopDbContextOptionsFactory, DonutShopDbContextOptionsFactory>();
        serviceCollection.AddSingleton<DbContextOptions<DonutShopDbContext>>(sp => sp.GetRequiredService<IDonutShopDbContextOptionsFactory>().Create());
        serviceCollection.AddDbContext<DonutShopDbContext>();
        
        serviceCollection.AddSingleton<IFileService, LocalFileService>();
        serviceCollection.AddSingleton<IInvoiceGenerator, TextInvoiceGenerator>();

        return serviceCollection;
    }
}