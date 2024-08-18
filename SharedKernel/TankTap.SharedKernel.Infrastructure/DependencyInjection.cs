using Autofac;
using TankTap.SharedKernel.Infrastructure.DomainEventDispatching;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.SharedKernel.Infrastructure;

public static class DependencyInjection
{
	public static void RegisterDomainEventDispatching(this ContainerBuilder builder)
	{
		builder.RegisterType<DomainEventDispatcher>()
			.As<IDomainEventDispatcher>()
			.InstancePerDependency();

		builder.RegisterType<DomainEventAccessor>()
			.As<IDomainEventAccessor>()
			.InstancePerDependency();
	}
	public static void AddInMemoryEventBus(this ContainerBuilder builder)
		=> builder
		.RegisterType<InMemoryEventBusClient>()
		.As<IEventBus>()
		.SingleInstance();
}
