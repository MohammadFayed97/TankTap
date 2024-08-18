using Microsoft.EntityFrameworkCore;
using TankTap.SharedKernel.Infrastructure.DomainEventDispatching;

namespace TankTap.SharedKernel.Infrastructure;

public class UnitOfWork(DbContext context, IDomainEventDispatcher domainEventDispatcher) : IUnitOfWork
{
	public async Task CommitAsync(CancellationToken cancellationToken = default)
	{
		await context.SaveChangesAsync(cancellationToken);
		await domainEventDispatcher.DispatchAsync(cancellationToken);
	}
}
