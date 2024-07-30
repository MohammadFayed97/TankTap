using TankTap.SharedKernel;

namespace TankTap.Stations.Domain.StationAggregate;

public class StationPointOfSale : Entity<int>
{
    public int StationId { get; }
    public POSDevice Device { get; }

    public StationPointOfSale(int stationId, POSDevice device)
    {
        StationId = stationId;
        Device = device;
    }
    private StationPointOfSale() { } // EF
}