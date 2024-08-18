using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.StationAggregate;

public sealed class Tank : Entity<int>
{
	private List<Pump> _pumps = [];

	public Tank(string code, decimal capacity, Station station, Product product)
	{
		Code = code;
		Capacity = capacity;
		StationId = station.Id;
		ProductId = product.Id;
		Product = product;
	}
	private Tank() { } // EF

	public void AddPump(string code, string erpCode)
	{
		var pump = new Pump(Id, code, erpCode);

		_pumps.Add(pump);
	}

	public string Code { get; }
	public decimal Capacity { get; }
	public int StationId { get; }
	public int ProductId { get; }
	public Product Product { get; }
	public IReadOnlyCollection<Pump> Pumps => _pumps.AsReadOnly();
}
