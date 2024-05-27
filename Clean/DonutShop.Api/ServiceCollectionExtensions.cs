using DonutShop.Api.Jwt;
using DonutShop.Api.Options;
using DonutShop.Application.Contracts;
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

        return serviceCollection;
    }
}