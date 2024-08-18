using TankTap.Invoices.Domain.ProductAggregate;

namespace TankTap.Invoices.Infrastructure.Repositories;

internal class ProductRepository(InvoicesContext context) : IProductRepository
{
	public async Task<Product> AddAsync(Product entity, CancellationToken cancellationToken = default)
	{
		var entry = await context.Products.AddAsync(entity, cancellationToken);

		return entry.Entity;
	}
}
