using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Infrastructure.Persistences.Repositories;
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

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
