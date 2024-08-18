using Autofac;
using TankTap.SharedKernel.Infrastructure;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Admistration.Infrastructure.Configurations.EventBus;

internal class EventBusModule(IEventBus eventBus) : Module
{
	protected override void Load(ContainerBuilder builder)
	{
        if(eventBus is null)
		    builder.AddInMemoryEventBus();
        else
            builder
				.RegisterInstance(eventBus)
				.As<IEventBus>()
				.SingleInstance();
	}
}
