using Ardalis.GuardClauses;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.PointOfSaleTypeAggregate;

public sealed class PointOfSaleType : Entity<int>, IAggregateRoot
{
	public LocalizedName Name { get; }

	public PointOfSaleType(LocalizedName name)
	{
		Name = Guard.Against.Null(name, nameof(name));
	}
	private PointOfSaleType() { } // EF

	public override string ToString() => Name;
}
