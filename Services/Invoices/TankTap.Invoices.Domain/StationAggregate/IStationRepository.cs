namespace TankTap.Invoices.Domain.StationAggregate;

public interface IStationRepository
{
	Task<Station> AddAsync(Station entity, CancellationToken cancellationToken = default);
}