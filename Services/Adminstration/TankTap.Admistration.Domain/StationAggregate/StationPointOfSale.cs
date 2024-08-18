using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.StationAggregate;

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