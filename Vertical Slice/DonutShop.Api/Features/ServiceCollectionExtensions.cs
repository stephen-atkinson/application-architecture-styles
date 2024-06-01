using DonutShop.Api.Features.Auth;
using DonutShop.Api.Features.Auth.Jwt;
using DonutShop.Api.Features.Orders.Invoices;
using DonutShop.Api.Shared.Database;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace DonutShop.Api.Features;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFeatures(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<JwtSettings>(configuration.GetRequiredSection("Jwt"));
        serviceCollection.AddSingleton<IAccessTokenGenerator, JwtGenerator>();
        
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        
        serviceCollection.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(assembly);
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        serviceCollection.AddValidatorsFromAssembly(assembly);
        
        serviceCollection.AddSingleton<IInvoiceService, InvoiceService>();
        serviceCollection.AddSingleton<IInvoiceGenerator, TextInvoiceGenerator>();

        return serviceCollection;
    }
}