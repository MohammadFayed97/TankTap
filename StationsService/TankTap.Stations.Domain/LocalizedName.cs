using TankTap.SharedKernel;

namespace TankTap.Stations.Domain;
public sealed class LocalizedName : ValueObject
{
    public string ArName { get; }
    public string EnName { get; }
    public string UrName { get; }
    public string BnName { get; }

    public LocalizedName(string nameAr,  string nameEn, string nameUr, string nameBn)
    {
        ArName = nameAr;
        EnName = nameEn;
        UrName = nameUr;
        BnName = nameBn;
    }

    private LocalizedName() { } // EF

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ArName;
        yield return EnName;
        yield return UrName;
        yield return BnName;
    }
    public override string ToString() => EnName;

    public static implicit operator string(LocalizedName name) => name?.ToString() ?? string.Empty;
}
