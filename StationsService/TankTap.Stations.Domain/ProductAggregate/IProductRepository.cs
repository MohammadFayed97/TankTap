namespace TankTap.Stations.Domain.ProductAggregate;

public interface IProductRepository
{
    Task<List<Product>> GetProductsByIdsAsync(int[] ids, CancellationToken cancellationToken = default);
}