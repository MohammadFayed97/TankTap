using Autofac;

namespace TankTap.Admistration.Infrastructure.Configurations;

internal class AdministrationCompositionRoot
{
    public static IContainer Container { get; private set; }
    public static ILifetimeScope CreateScope() => Container.BeginLifetimeScope();
    public static void SetContainer(IContainer container) => Container = container;
}


