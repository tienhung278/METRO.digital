using METRO.digital.Contracts;
using METRO.digital.Repositories;

namespace METRO.digital.Configuration;

public static class RepositoryConfiguration
{
    public static void ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IArtIcleRepository, ArtIcleRepository>();
    }
}