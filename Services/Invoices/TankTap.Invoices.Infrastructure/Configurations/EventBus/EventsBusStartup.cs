using Autofac;
using TankTap.SharedKernel.Infrastructure.EventBus;
using TankTap.Invoices.Application.Stations;
using TankTap.Invoices.Domain.StationAggregate;
using TankTap.SharedKernel.Infrastructure;
using TankTap.Invoices.Domain.ProductAggregate;

namespace TankTap.Invoices.Infrastructure.Configurations.EventBus;

internal static class EventBusStartup
{
	internal static void Initialize()
	{
		SubscribeToIntegrationEvents();
	}

	private static void SubscribeToIntegrationEvents()
	{
		var scope = InvoicesCompositionRoot.CreateScope();

		var eventBus = scope.Resolve<IEventBus>();
		var stationRepository = scope.Resolve<IStationRepository>();
		var productRepository = scope.Resolve<IProductRepository>();
		var unitOfWork = scope.Resolve<IUnitOfWork>();

		eventBus.SubscribeAsync(new StationCreatedIntegrationEventHandler(stationRepository, unitOfWork));
		eventBus.SubscribeAsync(new ProductCreatedIntegrationEventHandler(productRepository, unitOfWork));
	}
}
