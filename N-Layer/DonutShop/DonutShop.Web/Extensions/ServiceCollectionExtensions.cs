using DonutShop.BLL.Contracts;
using DonutShop.Web.ExceptionHandlers;
using DonutShop.Web.Models.Settings;
using DonutShop.Web.Options;
using DonutShop.Web.Services;
using Microsoft.AspNetCore.Diagnostics;

namespace DonutShop.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeb(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection.ConfigureOptions<RouteOptionsConfiguration>();
        serviceCollection.ConfigureOptions<JwtOptionsConfiguration>();
        serviceCollection.ConfigureOptions<SwaggerOptionsConfiguration>();
        
        serviceCollection.Configure<JwtSettings>(configuration.GetRequiredSection("Jwt"));

        serviceCollection.AddSingleton<IAccessTokenGenerator, JwtGenerator>();

        var exceptionHandlerType = typeof(IExceptionHandler);
        
        var exceptionHandlerTypes = assembly.GetTypes()
            .Where(t => !t.IsAbstract && t.GetInterfaces().Contains(exceptionHandlerType))
            .ToArray();

        foreach (var type in exceptionHandlerTypes)
        {
            serviceCollection.AddSingleton(exceptionHandlerType, type);
        }

        serviceCollection.AddExceptionHandler<ValidationExceptionHandler>();

        return serviceCollection;
    }
}