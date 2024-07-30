using Ardalis.GuardClauses;
using TankTap.SharedKernel;
using TankTap.Stations.Domain.CityAggregate;

namespace TankTap.Stations.Domain.RegionAggregate;

public sealed class Region : Entity<int>, IAggregateRoot
{

    private List<City> _cities = [];

    public Region(int id, LocalizedName name) : base(id)
    {
        Name = Guard.Against.Null(name, nameof(name));
    }
    private Region() { } // EF

    public void AddCity(City city)
    {
        Guard.Against.Null(city, nameof(city));

        _cities.Add(city);
    }
    public void AddCities(List<City> cities)
    {
        Guard.Against.Null(cities, nameof(cities));
        if (cities.Count == 0)
            return;

        _cities.AddRange(cities);
    }

    public LocalizedName Name { get; private set; }
    public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();
}
