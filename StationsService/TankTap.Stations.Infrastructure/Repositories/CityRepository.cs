using Microsoft.EntityFrameworkCore;
using TankTap.Stations.Domain.CityAggregate;
using TankTap.Stations.Infrastructure.Persistence;

namespace TankTap.Stations.Infrastructure.Repositories;

public class CityRepository(DataContext dataContext) : ICityRepository
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<City?> GetByIdAsync(int id, CancellationToken cancellationToken = default) 
        => await _dataContext.Cities.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
}
