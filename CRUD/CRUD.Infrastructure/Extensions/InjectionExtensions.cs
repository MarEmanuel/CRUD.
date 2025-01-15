using CRUD.Infrastructure.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var assembly = typeof(DatabaseContext).Assembly.FullName;

            services.AddDbContext<DatabaseContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("DatabaseConnection"),
                    b => b.MigrationsAssembly(assembly)
                    ), ServiceLifetime.Transient
                );

            return services;
        }
    }
}
