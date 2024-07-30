using Ardalis.GuardClauses;
using TankTap.SharedKernel;

namespace TankTap.Stations.Domain.ProductAggregate;

public sealed class Product : Entity<int>, IAggregateRoot
{
    public override string ToString() => Name;

    public LocalizedName Name { get; private set; }
    public string Code { get; private set; }
    public string ERPCode { get; private set; }
    public decimal Price { get; private set; }

    public Product(int id, LocalizedName name, string code, string erpCode, decimal price) : base(id)
    {
        Name = Guard.Against.Null(name, nameof(name));
        Code = Guard.Against.NullOrEmpty(code, nameof(code));
        ERPCode = Guard.Against.NullOrEmpty(erpCode, nameof(erpCode));
        Price = Guard.Against.Negative(price, nameof(price));
    }
    private Product() { } //EF
}