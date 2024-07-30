using Ardalis.GuardClauses;
using TankTap.SharedKernel;
using TankTap.Stations.Domain.PointOfSaleTypeAggregate;

namespace TankTap.Stations.Domain.StationAggregate;

public sealed class POSDevice : ValueObject
{
    public string Ip { get; }
    public string AndroidId { get; }
    public PointOfSaleType Type { get; }

    public POSDevice(string ip, string androidId, PointOfSaleType type)
    {
        Ip = Guard.Against.NullOrEmpty(ip, nameof(ip));
        AndroidId = Guard.Against.NullOrEmpty(androidId, nameof(androidId));
        Type = Guard.Against.Null(type, nameof(type));
    }
    private POSDevice() { } // EF

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Ip;
        yield return AndroidId;
        yield return Type;
    }
}