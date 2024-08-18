namespace TankTap.SharedKernel.Infrastructure.EventBus;

public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
	where TIntegrationEvent : IIntegrationEvent
{
	Task HandleAsync(TIntegrationEvent @event);
}
public interface IIntegrationEventHandler
{
}
