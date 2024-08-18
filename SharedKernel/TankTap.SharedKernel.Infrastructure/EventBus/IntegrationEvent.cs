namespace TankTap.SharedKernel.Infrastructure.EventBus;

public abstract class IntegrationEvent : IIntegrationEvent
{
	public Guid Id { get; }
	public DateTime CreationDate { get; }
	protected IntegrationEvent(Guid id, DateTime creationDate)
	{
		Id = id;
		CreationDate = creationDate;
	}
}
