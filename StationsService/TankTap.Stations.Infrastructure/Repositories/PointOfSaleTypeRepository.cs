using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using TankTap.Stations.Domain.PointOfSaleTypeAggregate;
using TankTap.Stations.Infrastructure.Persistence;

namespace TankTap.Stations.Infrastructure.Repositories;

public class PointOfSaleTypeRepository(DataContext dataContext) : IPointOfSaleTypeRepository
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<List<PointOfSaleType>> GetPOSTypesListByIds(int[] ids, CancellationToken cancellationToken = default) 
        => await _dataContext.PointOfSaleTypes
        .Where(e => ids.Contains(e.Id))
        .ToListAsync(cancellationToken);
}
