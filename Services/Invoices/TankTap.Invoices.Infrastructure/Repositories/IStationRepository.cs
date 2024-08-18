using TankTap.Invoices.Domain.StationAggregate;

namespace TankTap.Invoices.Infrastructure.Repositories;

internal class StationRepository(InvoicesContext context) : IStationRepository
{
	public async Task<Station> AddAsync(Station entity, CancellationToken cancellationToken = default)
	{
		var entry = await context.Stations.AddAsync(entity, cancellationToken);

		return entry.Entity;
	}
}