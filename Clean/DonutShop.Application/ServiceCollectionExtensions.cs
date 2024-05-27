using DonutShop.Application.Contracts;
using DonutShop.Application.Services;
using DonutShop.Application.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DonutShop.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        // Identity doesn't register this and throws an error - https://github.com/dotnet/aspnetcore/issues/53938
        serviceCollection.AddSingleton(TimeProvider.System);
        
        serviceCollection.AddIdentityCore<IdentityUser>()
            .AddUserManager<AspNetUserManager<IdentityUser>>()
            .AddSignInManager()
            .AddEntityFrameworkStores<DonutShopDbContext>();
        
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        
        serviceCollection.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(assembly);
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        serviceCollection.AddValidatorsFromAssembly(assembly);
        
        serviceCollection.AddSingleton<IInvoiceService, InvoiceService>();

        return serviceCollection;
    }
}