namespace TankTap.SharedKernel.Domain;

public abstract class BaseDomainEvent : IDomainEvent
{
	public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
	public Guid Id { get; private set; } = Guid.NewGuid();
}
