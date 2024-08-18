using MediatR;
using TankTap.Admistration.Domain.ProductAggregate.Events;
using TankTap.Admistration.IntegrationEvents;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Admistration.Application.Products.Add;

internal class ProductCreatedEventHandler(IEventBus eventBus) : INotificationHandler<ProductCreatedEvent>
{
	public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
	{
		var @event = new ProductCreatedIntegrationEvent(
			Guid.NewGuid(), 
			notification.DateOccurred.DateTime, 
			notification.Name, 
			notification.Price);

		await eventBus.PublishAsync(@event, cancellationToken);
	}
}
