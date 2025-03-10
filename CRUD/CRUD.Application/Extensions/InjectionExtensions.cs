using CRUD.Application.Interfaces;
using CRUD.Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CRUD.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IPersonaApplication, PersonaApplication>();
            services.AddScoped<IRolApplication, RolApplication>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IDashboardApplication, DashboardApplication>();
            services.AddScoped<ISesionApplication, SesionApplication>();
            services.AddScoped<IPermisoApplication, PermisoApplication>();
            services.AddScoped<IRegisterApplication, RegisterApplication>();
            services.AddScoped<ILoginApplication, LoginApplication>();

            return services;
        }
    }
}
