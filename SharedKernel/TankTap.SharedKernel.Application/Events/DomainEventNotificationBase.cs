using TankTap.SharedKernel.Domain;

namespace TankTap.SharedKernel.Application.Events;

public class DomainEventNotificationBase<T> : IDomainEventNotification<T>
	where T : IDomainEvent
{
        public DomainEventNotificationBase(T domainEvent, Guid id)
        {
		DomainEvent = domainEvent;
		Id = id;
	}

	public T DomainEvent { get; }
	public Guid Id { get; }
}
