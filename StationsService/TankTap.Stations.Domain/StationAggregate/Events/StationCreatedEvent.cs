using TankTap.SharedKernel;

namespace TankTap.Stations.Domain.StationAggregate.Events;

public class StationCreatedEvent(int id) : BaseDomainEvent
{
    public int Id { get; } = id;
}
