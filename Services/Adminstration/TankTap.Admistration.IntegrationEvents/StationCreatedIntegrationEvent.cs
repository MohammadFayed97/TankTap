using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Admistration.IntegrationEvents;

public class StationCreatedIntegrationEvent(
	Guid id,
	DateTime creationDate,
	string stationName) : IntegrationEvent(id, creationDate)
{
	public string StationName { get; } = stationName;
}