using MediatR;

namespace TankTap.SharedKernel.Infrastructure.EventBus;

public interface IIntegrationEvent : INotification
{
	Guid Id { get; }
	DateTime CreationDate { get; }
}
