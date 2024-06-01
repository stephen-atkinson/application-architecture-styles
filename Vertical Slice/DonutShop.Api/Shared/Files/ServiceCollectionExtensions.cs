namespace DonutShop.Api.Shared.Files;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFiles(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IFileService, LocalFileService>();
        
        return serviceCollection;
    }
}