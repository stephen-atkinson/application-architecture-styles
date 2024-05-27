using Microsoft.Extensions.Options;

namespace DonutShop.Api.Options;

public class RouteOptionsConfiguration : IConfigureOptions<RouteOptions>
{
    public void Configure(RouteOptions options)
    {
        options.LowercaseUrls = true;
    }
}