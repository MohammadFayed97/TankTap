using TankTap.SharedKernel.Domain;

namespace TankTap.Invoices.Domain.StationAggregate;

public class Station : Entity<int>, IAggregateRoot
{
	public string Name { get; }

	public Station(string name)
	{
		Name = name;
	}
	private Station() { } // EF Core
}