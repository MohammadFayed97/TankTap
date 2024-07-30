using Ardalis.GuardClauses;
using TankTap.SharedKernel;
using TankTap.Stations.Domain.Commons;
using TankTap.Stations.Domain.ProductAggregate;
using TankTap.Stations.Domain.Results;

namespace TankTap.Stations.Domain.StationAggregate;

public sealed class Station : Entity<int>, IAggregateRoot
{
    private readonly List<Tank> _tanks = [];
    private readonly List<StationProduct> _stationProducts = [];
    private readonly List<POSDevice> _pointOfSales = [];

    private Station(int id, string name, string code, string erpCode, StationAddress address)
        : base(id)
    {
        Name = name;
        Code = code;
        ERPCode = erpCode;
        Address = address;
    }
    private Station() { } // EF

    public static IResult<Station> Create(string name, string code, string erpCode, StationAddress address)
    {
        try
        {
            Guard.Against.NullOrEmpty(name, message: ValidationMessages.NotNullOrEmpty(nameof(name)));
            Guard.Against.NullOrEmpty(code, message: ValidationMessages.NotNullOrEmpty(nameof(code)));
            Guard.Against.NullOrEmpty(erpCode, message: ValidationMessages.NotNullOrEmpty(nameof(erpCode)));
            Guard.Against.Null(address, ValidationMessages.NotNull(nameof(address)));

            var station = new Station(default, name, code, erpCode, address);

            return Result<Station>.Success(station);
        }
        catch (Exception exception)
        {
            return Result<Station>.Fail(exception.Message);
        }
    }

    public Tank AddTank(string code, decimal capacity, Product product)
    {
        Guard.Against.NullOrEmpty(code, nameof(code));
        Guard.Against.Negative(capacity, nameof(capacity));
        Guard.Against.Null(product, nameof(product));

        var tank = new Tank(code, capacity, this, product);

        _tanks.Add(tank);

        return tank;
    }
    public void AddProduct(Product product) => AddProduct(product, product.Price);
    public void AddProduct(Product product, decimal newPrice)
    {
        Guard.Against.Null(product, nameof(product));
        Guard.Against.Negative(newPrice, nameof(newPrice));

        var stationProductToAdd = new StationProduct(Id, product, newPrice);

        _stationProducts.Add(stationProductToAdd);
    }
    public void AddProducts(Dictionary<Product, decimal> products)
    {
        foreach (var product in products)
        {
            AddProduct(product.Key, product.Value);
        }
    }
    public void AddPOS(params POSDevice[] posDevices)
    {
        var stationDevices = posDevices
            .Where(e => e is not null);
        
        _pointOfSales.AddRange(stationDevices);
    }

    public string Name { get; private set; }
    public Distination Distination { get; set; }
    public StationAddress Address { get; private set; }
    public string Code { get; private set; }
    public string ERPCode { get; private set; }
    public IReadOnlyCollection<Tank> Tanks => _tanks.AsReadOnly();
    public IReadOnlyCollection<StationProduct> StationProducts => _stationProducts.AsReadOnly();
    public IReadOnlyCollection<Product> Products => StationProducts.Select(e => e.Product).ToArray();
    public IReadOnlyCollection<Pump> Pumps => Tanks.SelectMany(e => e.Pumps).ToArray();
    public IReadOnlyCollection<POSDevice> PointOfSales => _pointOfSales.AsReadOnly();
}
