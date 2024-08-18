namespace TankTap.Invoices.Domain.ProductAggregate;

public interface IProductRepository
{
	Task<Product> AddAsync(Product entity, CancellationToken cancellationToken = default);
}