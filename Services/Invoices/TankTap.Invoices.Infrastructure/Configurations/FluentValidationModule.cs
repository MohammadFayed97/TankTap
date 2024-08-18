using Autofac;
using FluentValidation;
using TankTap.Invoices.Application;

namespace TankTap.Admistration.Infrastructure.Configurations;

internal class FluentValidationModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterAssemblyTypes(typeof(IInvoicesModule).Assembly, ThisAssembly)
			.Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
			.AsImplementedInterfaces()
			.InstancePerLifetimeScope();
	}
}
