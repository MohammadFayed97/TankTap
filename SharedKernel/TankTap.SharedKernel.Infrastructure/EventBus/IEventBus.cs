namespace TankTap.SharedKernel.Infrastructure.EventBus;

public interface IEventBus : IDisposable
{
	Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) 
		where TEvent : IIntegrationEvent;

	Task SubscribeAsync<TEvent>(IIntegrationEventHandler<TEvent> handler, CancellationToken cancellationToken = default)
		where TEvent : IIntegrationEvent;
}