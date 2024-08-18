using Autofac;
using TankTap.SharedKernel.Infrastructure;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Invoices.Infrastructure.Configurations.EventBus;

internal class EventBusModule(IEventBus eventBus) : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		if (eventBus is null)
			builder.AddInMemoryEventBus();
		else
			builder
				.RegisterInstance(eventBus)
				.As<IEventBus>()
				.SingleInstance();
	}
}
