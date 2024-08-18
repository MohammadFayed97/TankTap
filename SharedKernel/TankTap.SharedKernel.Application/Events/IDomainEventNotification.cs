using MediatR;
using TankTap.SharedKernel.Domain;

namespace TankTap.SharedKernel.Application.Events;

public interface IDomainEventNotification : INotification
{
	Guid Id { get; }
}

public interface IDomainEventNotification<out T> : IDomainEventNotification
	where T : IDomainEvent
{
	T DomainEvent { get; }
}