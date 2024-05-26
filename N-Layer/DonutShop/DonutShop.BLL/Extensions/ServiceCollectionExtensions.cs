using DonutShop.BLL.Contracts;
using DonutShop.BLL.Services;
using DonutShop.BLL.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DonutShop.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBll(this IServiceCollection serviceCollection)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        
        serviceCollection.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(assembly);
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        serviceCollection.AddValidatorsFromAssembly(assembly);

        serviceCollection.AddSingleton<IFileService, LocalFileService>();
        serviceCollection.AddSingleton<IInvoiceService, InvoiceService>();
        serviceCollection.AddSingleton<IInvoiceGenerator, TextInvoiceGenerator>();
        
        return serviceCollection;
    }
}