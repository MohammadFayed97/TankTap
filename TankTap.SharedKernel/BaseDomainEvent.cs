using MediatR;

namespace TankTap.SharedKernel;

public abstract class BaseDomainEvent : INotification
{
    public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
    public Guid Id { get; private set; } = Guid.NewGuid();
}