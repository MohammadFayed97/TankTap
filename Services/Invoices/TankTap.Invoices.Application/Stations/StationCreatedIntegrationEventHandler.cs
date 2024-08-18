using TankTap.Admistration.IntegrationEvents;
using TankTap.Invoices.Domain.StationAggregate;
using TankTap.SharedKernel.Infrastructure;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Invoices.Application.Stations;

public class StationCreatedIntegrationEventHandler(IStationRepository stationRepository, IUnitOfWork unitOfWork) 
	: IIntegrationEventHandler<StationCreatedIntegrationEvent>
{
	private readonly IStationRepository _stationRepository = stationRepository;
	private readonly IUnitOfWork _unitOfWork = unitOfWork;

	public async Task HandleAsync(StationCreatedIntegrationEvent @event)
	{
		var newStation = new Station(@event.StationName);

		await _stationRepository.AddAsync(newStation);
		await _unitOfWork.CommitAsync();
	}
}
