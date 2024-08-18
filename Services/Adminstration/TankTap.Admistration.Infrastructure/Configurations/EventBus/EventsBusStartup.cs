using Autofac;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Admistration.Infrastructure.Configurations.EventBus;

internal static class EventBusStartup
{
    internal static void Initialize()
    {
        SubscribeToIntegrationEvents();
    }

    private static void SubscribeToIntegrationEvents()
    {
        var eventBus = AdministrationCompositionRoot.CreateScope().Resolve<IEventBus>();

        //eventBus.SubscribeAsync<StationCreatedIntegrationEvent>()
    }
}
