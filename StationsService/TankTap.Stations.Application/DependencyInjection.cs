using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TankTap.Stations.Application.Behaviours;
using TankTap.Stations.Domain;

namespace TankTap.Stations.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        Assembly[] assemblies = [typeof(Application.IAssemblyMarker).Assembly, typeof(Domain.IAssemblyMarker).Assembly];

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assemblies);
            config.AddOpenRequestPreProcessor(typeof(RequestLogger<>));
            config.AddOpenBehavior(typeof(RequestPerformanceBehaviour<,>));
            //config.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
        });

        return services;
    }
}
