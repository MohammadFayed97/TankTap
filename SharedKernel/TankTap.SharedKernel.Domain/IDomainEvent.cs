using MediatR;

namespace TankTap.SharedKernel.Domain;

public interface IDomainEvent : INotification
{
	DateTimeOffset DateOccurred { get; }
	Guid Id { get; }
}