using TankTap.SharedKernel.Domain;

namespace TankTap.SharedKernel.Infrastructure.DomainEventDispatching;

public interface IDomainEventAccessor
{
	void ClearAllDomainEvents();
	IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();
}