namespace TankTap.SharedKernel.Infrastructure.EventBus;

internal class InMemoryEventBus
{
	static InMemoryEventBus()
	{
	}
	private InMemoryEventBus()
	{
	}

	public static InMemoryEventBus Instance = new InMemoryEventBus();

	private readonly Dictionary<Type, List<IIntegrationEventHandler>> _handlers = [];

	public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
		where TEvent : IIntegrationEvent
	{
		var eventType = @event.GetType();
		if (_handlers.TryGetValue(eventType, out List<IIntegrationEventHandler>? handlers))
		{
			foreach (IIntegrationEventHandler integrationHandler in handlers)
			{
				if (integrationHandler is IIntegrationEventHandler<TEvent> handler)
				{
					if (cancellationToken.IsCancellationRequested)
						throw new OperationCanceledException("Handling process was canceled.");

					await handler.HandleAsync(@event);
				}
			}
		}
	}

	public async Task SubscribeAsync<TEvent>(IIntegrationEventHandler<TEvent> handler, CancellationToken cancellationToken = default)
		where TEvent : IIntegrationEvent
	{

		var eventType = typeof(TEvent);

		if (eventType is null || handler is null)
			await Task.CompletedTask;

		if (!_handlers.ContainsKey(eventType!))
			_handlers[eventType!] = [];

		_handlers[eventType!].Add(handler!);

		if (cancellationToken.IsCancellationRequested)
		{
			_handlers[eventType!].Remove(handler!);

			throw new OperationCanceledException("Subscription process was canceled.");
		}

		await Task.CompletedTask;
	}

	public async Task UnSubscribeAllAsync()
	{
		_handlers.Clear();
		await Task.CompletedTask;
	}
}