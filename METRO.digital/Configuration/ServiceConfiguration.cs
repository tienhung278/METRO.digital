using METRO.digital.Contracts;
using METRO.digital.Services;

namespace METRO.digital.Configuration;

public static class ServiceConfiguration
{
    public static void ConfigureService(this IServiceCollection services)
    {
        services.AddScoped<IBasketServices, BasketServices>();
        services.AddScoped<IArtIcleServices, ArtIcleServices>();
    }
}