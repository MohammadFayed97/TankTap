﻿using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using TankTap.Stations.Domain.StationAggregate;
using TankTap.Stations.Infrastructure.Persistence;

namespace TankTap.Stations.Infrastructure.Repositories;

public class StationRepository(DataContext Context) : IStationRepository
{
    public async Task AddAsync(Station station, CancellationToken cancellationToken = default)
    {
        await Context.AddAsync(station, cancellationToken);
        await Context.SaveChangesAsync();
    }

    public async Task<bool> CheckIfStationCodeExistsBefore(string code, CancellationToken cancellationToken = default) 
        => await Context.Stations.AnyAsync(e => e.Code == code, cancellationToken: cancellationToken);

    public async Task<bool> CheckIfStationERPCodeExistsBefore(string erpCode, CancellationToken cancellationToken = default) 
        => await Context.Stations.AnyAsync(e => e.ERPCode == erpCode, cancellationToken: cancellationToken);

    public async Task<bool> IsAnyPOSDevicesExists(POSDeviceModel[] posDeviceModels, CancellationToken cancellationToken = default) 
        => await Task.FromResult(Context.Stations
            .Include(e => e.PointOfSales)
            .SelectMany(e => e.PointOfSales)
            .Any(e => posDeviceModels.Any(p => p.POSId == e.Ip || p.AndroidId == e.AndroidId)));
}
