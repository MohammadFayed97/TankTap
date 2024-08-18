using MediatR;
using TankTap.Admistration.Domain.StationAggregate.Events;
using TankTap.Admistration.IntegrationEvents;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Admistration.Application.Stations.Add;

internal class StationCreatedEventHandler(IEventBus eventBus) : INotificationHandler<StationCreatedEvent>
{
	public async Task Handle(StationCreatedEvent notification, CancellationToken cancellationToken)
	{
		await eventBus.PublishAsync(
			new StationCreatedIntegrationEvent(
				Guid.NewGuid(), 
				notification.DateOccurred.DateTime, 
				notification.StationName), 
			cancellationToken);
	}
}
