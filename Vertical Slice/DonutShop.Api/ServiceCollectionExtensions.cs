using DonutShop.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;

namespace DonutShop.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWeb(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();

        serviceCollection.AddProblemDetails();
        
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        serviceCollection.ConfigureOptions<RouteOptionsConfiguration>();
        serviceCollection.ConfigureOptions<JwtOptionsConfiguration>();
        serviceCollection.ConfigureOptions<SwaggerOptionsConfiguration>();

        var exceptionHandlerType = typeof(IExceptionHandler);
        
        var exceptionHandlerTypes = assembly.GetTypes()
            .Where(t => !t.IsAbstract && t.GetInterfaces().Contains(exceptionHandlerType))
            .ToArray();

        foreach (var type in exceptionHandlerTypes)
        {
            serviceCollection.AddSingleton(exceptionHandlerType, type);
        }

        return serviceCollection;
    }
}