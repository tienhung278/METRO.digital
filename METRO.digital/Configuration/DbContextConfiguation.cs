using METRO.digital.Repositories;
using Microsoft.EntityFrameworkCore;

namespace METRO.digital.Configuration;

public static class DbContextConfiguation
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlite(connectionString);
        });
    }
}