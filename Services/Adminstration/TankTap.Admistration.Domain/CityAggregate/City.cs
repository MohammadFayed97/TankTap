using Ardalis.GuardClauses;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.CityAggregate;

public sealed class City : Entity<int>, IAggregateRoot
{
	public City(int id, LocalizedName name, int regionId) : base(id)
	{
		Name = Guard.Against.Null(name, nameof(name));
		RegionId = Guard.Against.NegativeOrZero(regionId, nameof(regionId));
	}

	private City() { } // EF
	public LocalizedName Name { get; private set; }
	public int RegionId { get; private set; }

	public override string ToString() => Name;
}
