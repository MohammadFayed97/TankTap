using Autofac;

namespace TankTap.SharedKernel.Infrastructure;

public class ServiceProviderWrapper(ILifetimeScope lifeTimeScope) : IServiceProvider
{
	public object? GetService(Type serviceType) => lifeTimeScope.ResolveOptional(serviceType);
}
