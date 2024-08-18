namespace TankTap.SharedKernel.Infrastructure.DomainEventDispatching;

public interface IDomainEventDispatcher
{
	Task DispatchAsync(CancellationToken cancellationToken = default);
}