using ECommerceApp.Application.Contracts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureRegistrationDI
    {
        public static IServiceCollection AddInfrastructureToDI(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<ECommerceAppContext>(
                options =>
                options.UseNpgsql(
                    configuration.GetConnectionString
                    ("ECommerceAppConnection"),
                    builder =>
                    builder.MigrationsAssembly(
                        typeof(ECommerceAppContext)
                        .Assembly.FullName)));
            services.AddScoped
                (typeof(IAsyncRepository<>),
                typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}

