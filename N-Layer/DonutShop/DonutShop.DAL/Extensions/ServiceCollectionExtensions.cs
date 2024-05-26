using DonutShop.DAL.Configurations;
using DonutShop.DAL.Contracts;
using DonutShop.DAL.Factories;
using DonutShop.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DonutShop.DAL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDal(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<DatabaseSettings>(configuration.GetRequiredSection("Database"));
        
        serviceCollection.AddSingleton<IConfigureModelBuilder<DonutShopDbContext>, DonutShopModelBuilderConfiguration>();
        serviceCollection.AddSingleton<IDonutShopDbContextOptionsFactory, DonutShopDbContextOptionsFactory>();
        serviceCollection.AddSingleton<DbContextOptions<DonutShopDbContext>>(sp => sp.GetRequiredService<IDonutShopDbContextOptionsFactory>().Create());
        serviceCollection.AddDbContext<DonutShopDbContext>();

        // Identity doesn't register this and throws an error - https://github.com/dotnet/aspnetcore/issues/53938
        serviceCollection.AddSingleton(TimeProvider.System);
        
        serviceCollection.AddIdentityCore<IdentityUser>()
            .AddUserManager<AspNetUserManager<IdentityUser>>()
            .AddSignInManager()
            .AddEntityFrameworkStores<DonutShopDbContext>();

        return serviceCollection;
    }
}