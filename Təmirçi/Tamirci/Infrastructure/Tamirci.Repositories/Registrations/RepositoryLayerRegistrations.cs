using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tamirci.Repositories.HttpContextCache;
using Tamirci.Repository.Contracts.HttpContextCache;

namespace Tamirci.Repositories.Registrations;

public static class RepositoryLayerRegistrations
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("Default")));
        services.AddScoped(typeof(IHttpContextCacheRepository<>), typeof(HttpContextCacheRepository<>));

    }
}
