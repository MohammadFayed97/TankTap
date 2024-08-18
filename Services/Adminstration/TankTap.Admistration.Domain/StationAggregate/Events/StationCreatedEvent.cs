using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.StationAggregate.Events;

public class StationCreatedEvent(int id, string name) : BaseDomainEvent
{
	public int StationId { get; } = id;
	public string StationName { get; } = name;
}
