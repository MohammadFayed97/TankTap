namespace TankTap.Admistration.Domain.StationAggregate;

public interface IStationRepository
{
	Task<bool> IsAnyPOSDevicesExists(POSDeviceModel[] posDeviceModels, CancellationToken cancellationToken = default);
	Task<bool> CheckIfStationCodeExistsBefore(string code, CancellationToken cancellationToken = default);
	Task<bool> CheckIfStationERPCodeExistsBefore(string erpCode, CancellationToken cancellationToken = default);
	Task AddAsync(Station station, CancellationToken cancellationToken = default);
}
