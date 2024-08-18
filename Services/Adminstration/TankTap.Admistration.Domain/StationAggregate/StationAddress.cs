using Ardalis.GuardClauses;
using TankTap.Admistration.Domain.CityAggregate;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.StationAggregate;

public sealed class StationAddress : ValueObject
{
	public City City { get; }
	public string District { get; }

	public StationAddress(City city, string district)
	{
		City = Guard.Against.Null(city, nameof(city));
		District = Guard.Against.NullOrEmpty(district, nameof(district));
	}
	private StationAddress() { } // EF

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return City.Id;
		yield return District;
	}

	public override string ToString() => $"{City} {District}";
}
