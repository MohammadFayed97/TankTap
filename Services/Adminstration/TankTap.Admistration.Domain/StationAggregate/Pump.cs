using Ardalis.GuardClauses;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.StationAggregate;

public sealed class Pump : Entity<int>
{
	public int TankId { get; }
	public string Code { get; }
	public string ERPCode { get; }

	public Pump(int tankId, string code, string erpCode)
	{
		TankId = tankId;
		Code = Guard.Against.NullOrEmpty(code, nameof(code));
		ERPCode = Guard.Against.NullOrEmpty(erpCode, nameof(erpCode));
	}
	private Pump() { } //EF
}