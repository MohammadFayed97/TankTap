namespace TankTap.Stations.Domain.CityAggregate;

public interface ICityRepository
{
    Task<City?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
