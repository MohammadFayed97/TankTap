using Autofac;

namespace TankTap.Invoices.Infrastructure.Configurations;

internal class InvoicesCompositionRoot
{
	public static IContainer Container { get; private set; }
	public static ILifetimeScope CreateScope() => Container.BeginLifetimeScope();
	public static void SetContainer(IContainer container) => Container = container;
}


