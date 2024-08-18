using Serilog;

namespace TankTap.SharedKernel.Infrastructure.EventBus
{
	public class InMemoryEventBusClient(ILogger logger) : IEventBus
	{
		private readonly ILogger _logger = logger;

		public void Dispose() => InMemoryEventBus.Instance.UnSubscribeAllAsync().Wait();

		public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
			where TEvent : IIntegrationEvent
		{
			_logger.Information("Publishing event: {Event}", @event.GetType().FullName);
			await InMemoryEventBus.Instance.PublishAsync(@event, cancellationToken);
		}

		public async Task SubscribeAsync<TEvent>(IIntegrationEventHandler<TEvent> handler, CancellationToken cancellationToken = default)
			where TEvent : IIntegrationEvent
		{
			_logger.Information("Subscribing to event: {Event}", typeof(TEvent).Name);
			await InMemoryEventBus.Instance.SubscribeAsync(handler, cancellationToken);
		}
	}
}
