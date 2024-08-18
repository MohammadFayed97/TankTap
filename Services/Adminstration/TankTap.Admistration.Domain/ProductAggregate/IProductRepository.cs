namespace TankTap.Admistration.Domain.ProductAggregate;

public interface IProductRepository
{
	Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default);
	Task<List<Product>> GetProductsByIdsAsync(int[] ids, CancellationToken cancellationToken = default);
}