using DonutShop.Api.Shared.Database.Configurations;
using DonutShop.Api.Shared.Database.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DonutShop.Api.Shared.Database;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
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