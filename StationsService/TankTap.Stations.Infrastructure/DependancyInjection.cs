using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TankTap.SharedKernel;
using TankTap.Stations.Domain.CityAggregate;
using TankTap.Stations.Domain.PointOfSaleTypeAggregate;
using TankTap.Stations.Domain.ProductAggregate;
using TankTap.Stations.Domain.StationAggregate;
using TankTap.Stations.Infrastructure.Persistence;
using TankTap.Stations.Infrastructure.Repositories;

namespace TankTap.Stations.Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPointOfSaleTypeRepository, PointOfSaleTypeRepository>();

            //services.AddScoped<TankTapDbContextFactory>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString(TankTabDbContextSchema.DefaultConnectionStringName),
                    sqlOptions => sqlOptions.MigrationsAssembly(typeof(IAssemblyMarker).Assembly.FullName));
            });

            return services;
        }
    }
}
