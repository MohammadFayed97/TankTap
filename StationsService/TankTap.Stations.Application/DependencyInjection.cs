using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TankTap.Stations.Application.Behaviours;

namespace TankTap.Stations.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<IAssemblyMarker>();
            config.AddOpenRequestPreProcessor(typeof(RequestLogger<>));
            config.AddOpenBehavior(typeof(RequestPerformanceBehaviour<,>));
            //config.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
        });

        return services;
    }
}
