using TankTap.Stations.Domain;
using TankTap.Stations.Domain.CityAggregate;
using TankTap.Stations.Domain.Results;
using TankTap.Stations.Domain.StationAggregate;

namespace TankTap.Tests.Stations
{
    public class StationConstructionTests
    {
        private readonly City _city;
        private readonly string _name = "Test Station";
        private readonly string _code = "station code";
        private readonly string _erpCode = "station erp code";
        private readonly StationAddress _address;

        public StationConstructionTests()
        {
            var cityName = new LocalizedName("مدينة تيست", "Test City", "", "");
            _city = new City(10, cityName, 1);

            _address = new StationAddress(_city, "test district");

        }
        [Fact]
        public void Create_ValidData_StationCreated()
        {
            // act
            IResult<Station> creationResult = Station.Create(_name, _code, _erpCode, _address);

            // assert
            Assert.NotNull(creationResult);
            Assert.True(creationResult.IsSuccess);
            Assert.NotNull(creationResult.Data);

            Assert.Equal(_name, creationResult.Data.Name);
            Assert.Equal(_code, creationResult.Data.Code);
            Assert.Equal(_erpCode, creationResult.Data.ERPCode);
            Assert.Equal(_address, creationResult.Data.Address);
            Assert.Empty(creationResult.Data.Events);
            Assert.Empty(creationResult.Data.Tanks);
            Assert.Empty(creationResult.Data.StationProducts);
            Assert.Empty(creationResult.Data.Products);
            Assert.Empty(creationResult.Data.PointOfSales);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Create_NullOrEmptyName_StationCreationFailed(string? name)
        {
            // act
            IResult<Station> creationResult = Station.Create(name!, _code, _erpCode, _address);

            Assert.NotNull(creationResult);
            Assert.False(creationResult.IsSuccess);
            Assert.Null(creationResult.Data);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Create_NullOrEmptyCode_StationCreationFailed(string? code)
        {
            // act
            IResult<Station> creationResult = Station.Create(_name, code!, _erpCode, _address);

            Assert.NotNull(creationResult);
            Assert.False(creationResult.IsSuccess);
            Assert.Null(creationResult.Data);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Create_NullOrEmptyERPCode_StationCreationFailed(string? erpCode)
        {
            // act
            IResult<Station> creationResult = Station.Create(_name, _code, erpCode, _address);

            Assert.NotNull(creationResult);
            Assert.False(creationResult.IsSuccess);
            Assert.Null(creationResult.Data);
        }

        [Fact]
        public void Create_NullAddress_StationCreationFailed()
        {
            // act
            IResult<Station> creationResult = Station.Create(_name, _code, _erpCode, null);

            Assert.NotNull(creationResult);
            Assert.False(creationResult.IsSuccess);
            Assert.Null(creationResult.Data);
        }
    }
}