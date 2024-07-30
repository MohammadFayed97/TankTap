using TankTap.SharedKernel;

namespace TankTap.Stations.Domain.StationAggregate;

public interface IStationRepository : IRepository<Station>
{
    Task<bool> IsAnyPOSDevicesExists(POSDeviceModel[] posDeviceModels, CancellationToken cancellationToken = default);
}
public class POSDeviceModel
{
    public string POSId { get; set; }
    public string AndroidId { get; set; }
}
