using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.Admistration.Infrastructure.Persistence;

namespace TankTap.Admistration.Infrastructure.Repositories;

public class ProductRepository(AdminstartionContext dataContext) : IProductRepository
{
	private readonly AdminstartionContext _dataContext = dataContext;

	public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
	{
		var entry = await _dataContext.Products.AddAsync(product, cancellationToken);

		return entry.Entity;
	}

	public async Task<List<Product>> GetProductsByIdsAsync(int[] ids, CancellationToken cancellationToken = default)
		=> await _dataContext.Products.Where(e => ids.Contains(e.Id)).ToListAsync();
}
