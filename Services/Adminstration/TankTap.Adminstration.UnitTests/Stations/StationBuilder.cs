using TankTap.Admistration.Domain;
using TankTap.Admistration.Domain.CityAggregate;
using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.Admistration.Domain.StationAggregate;
using TankTap.SharedKernel.Domain;

namespace TankTap.Tests.Stations
{
	public class StationBuilder
    {
        private readonly string _name;
        private readonly string _code;
        private readonly string _erpCode;
        private readonly StationAddress _stationAddress;
        private (string TankCode, int TankCapacity, Product TankProduct)[] _tanks;

        public StationBuilder(string name, string code, string erpCode, StationAddress stationAddress)
        {
            _name = name;
            _code = code;
            _erpCode = erpCode;
            _stationAddress = stationAddress;
        }

        public static StationBuilder Default()
        {
            var cityName = new LocalizedName("مدينة تيست", "Test City", "", "");
            var city = new City(10, cityName, 1);

            var address = new StationAddress(city, "test district");

            return new StationBuilder("Test Station", "station code", "station erp code", address);
        }
        public StationBuilder WithNumberOfTanks(int numberOfTanks)
        {
            _tanks = Enumerable
                .Range(1, numberOfTanks)
                .ToList()
                .Select(itratorNumber =>
                {
                    var tankCode = "Tank " + itratorNumber;
                    var tankCapacity = 10 * itratorNumber;
                    var tankProduct = new Product(
                        new LocalizedName("المنتج " + itratorNumber, "product " + itratorNumber, "", ""),
                        "product code " + itratorNumber,
                        "product erp code" + itratorNumber,
                        1.84M * itratorNumber);

                    return (tankCode, tankCapacity, tankProduct);
                }).ToArray();

            return this;
        }
        public Station Build()
        {
            var station = Station.Create(_name, _code, _erpCode, _stationAddress).Data;

            if (_tanks.Any())
                _tanks.ToList().ForEach(e => station.AddTank(e.TankCode, e.TankCapacity, e.TankProduct));

            return station;
        }
    }
}
