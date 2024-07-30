using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using TankTap.Stations.Domain.StationAggregate;
using TankTap.Stations.Infrastructure.Persistence;

namespace TankTap.Stations.Infrastructure.Repositories;

public class StationRepository(DataContext dbContext) : EfRepository<Station>(dbContext), IStationRepository
{
    public async Task<bool> IsAnyPOSDevicesExists(POSDeviceModel[] posDeviceModels, CancellationToken cancellationToken = default) 
        => await Task.FromResult(Context.Stations
            .Include(e => e.PointOfSales)
            .SelectMany(e => e.PointOfSales)
            .Any(e => posDeviceModels.Any(p => p.POSId == e.Ip || p.AndroidId == e.AndroidId)));
}