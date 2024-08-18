using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain;

public sealed class Distination : ValueObject
{
	public string Longitude { get; private set; }
	public string Latitude { get; private set; }

	public Distination(string longitude, string latitude)
	{
		Longitude = longitude;
		Latitude = latitude;
	}
	private Distination() { } // EF

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Longitude;
		yield return Latitude;
	}
}
