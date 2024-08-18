using TankTap.Admistration.Domain;
using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.Admistration.Domain.StationAggregate;
using TankTap.SharedKernel.Domain;
using TankTap.Tests.Stations;

namespace TankTap.Adminstration.UnitTests.Stations;

public class AddTankToStationTests
{
	private Station _station;
	private readonly string _tankCode;
	private readonly decimal _tankCapacity;
	private readonly Product _tankProduct;

	public AddTankToStationTests()
	{
		_station = StationBuilder.Default().Build();
		_tankCode = "Tank code";
		_tankCapacity = 100;
		_tankProduct = new Product(new LocalizedName("المنتج 1", "product 1", "", ""), "product code", "product erp code", 1.84M);
	}

	[Fact]
	public void AddTank_ValidData_TankAddedToStation()
	{
		_station.AddTank(_tankCode, _tankCapacity, _tankProduct);

		Assert.NotEmpty(_station.Tanks);
		Assert.Single(_station.Tanks);

		var tankToAssert = _station.Tanks.First();
		Assert.Equal(tankToAssert.Code, _tankCode);
		Assert.Equal(tankToAssert.Capacity, _tankCapacity);
		Assert.Equal(tankToAssert.Product, _tankProduct);
	}

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public void AddTank_NulOrEmptyCode_ThrowArgumentException(string? code)
	{
		var addTankAction = () => _station.AddTank(code!, _tankCapacity, _tankProduct);

		if (code == string.Empty)
			Assert.Throws<ArgumentException>(addTankAction);
		else
			Assert.Throws<ArgumentNullException>(addTankAction);

	}

	[Fact]
	public void AddTank_NegativeCapacity_ThrowArgumentException()
	{
		var addTankAction = () => _station.AddTank(_tankCode, -10, _tankProduct);

		Assert.Throws<ArgumentException>(addTankAction);
	}
	[Fact]
	public void AddTank_NullProduct_ThrowArgumentNullException()
	{
		var addTankAction = () => _station.AddTank(_tankCode, _tankCapacity, null!);

		Assert.Throws<ArgumentNullException>(addTankAction);
	}
}
