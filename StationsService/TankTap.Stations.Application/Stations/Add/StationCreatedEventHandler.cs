using MediatR;
using TankTap.Stations.Domain.StationAggregate.Events;

namespace TankTap.Stations.Application.Stations.Add;

internal class StationCreatedEventHandler : INotificationHandler<StationCreatedEvent>
{
    public async Task Handle(StationCreatedEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Station created successfully with id: {0}", notification.Id);

        await Task.CompletedTask;
    }
}
