using Autofac;
using TankTap.SharedKernel.Infrastructure;

namespace TankTap.Admistration.Infrastructure.Configurations.Processing;

internal class ProcessingModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterDomainEventDispatching();

		builder
			.RegisterType<UnitOfWork>()
			.As<IUnitOfWork>()
			.InstancePerLifetimeScope();
	}
}
