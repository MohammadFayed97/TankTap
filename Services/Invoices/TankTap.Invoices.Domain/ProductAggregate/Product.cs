using TankTap.SharedKernel.Domain;

namespace TankTap.Invoices.Domain.ProductAggregate;

public class Product : Entity<int>, IAggregateRoot
{
    public LocalizedName Name { get; }
    public decimal Price { get; }

	public Product(LocalizedName name, decimal price)
	{
		Name = name;
		Price = price;
	}
    private Product() { } // EF Core
}
