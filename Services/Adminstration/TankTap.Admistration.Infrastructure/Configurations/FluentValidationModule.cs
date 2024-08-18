using Autofac;
using FluentValidation;

namespace TankTap.Admistration.Infrastructure.Configurations;

internal class FluentValidationModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterAssemblyTypes(typeof(Application.IAssemblyMarker).Assembly, ThisAssembly)
			.Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
			.AsImplementedInterfaces()
			.InstancePerLifetimeScope();
	}
}
