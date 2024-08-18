using Microsoft.EntityFrameworkCore;
using TankTap.SharedKernel.Domain;

namespace TankTap.SharedKernel.Infrastructure.DomainEventDispatching;

internal class DomainEventAccessor(DbContext context) : IDomainEventAccessor
{
	private DbContext _context = context;

	public IReadOnlyCollection<IDomainEvent> GetAllDomainEvents()
	{
		var entitiesWithEvents = _context.ChangeTracker
			.Entries()
			.Select(e => e.Entity as IDomainEntity)
			.Where(e => e?.Events is not null && e.Events.Count != 0)
			.ToArray();

		return entitiesWithEvents.SelectMany(e => e!.Events).ToList();
	}
	public void ClearAllDomainEvents()
	{
		IDomainEntity[] entitiesWithEvents = _context.ChangeTracker
			.Entries()
			.Select(e => e.Entity as IDomainEntity)
			.Where(e => e?.Events is not null && e.Events.Count != 0)
			.ToArray()!;

		foreach (IDomainEntity entity in entitiesWithEvents)
		{
			entity.ClearDomainEvents();
		}
	}
}