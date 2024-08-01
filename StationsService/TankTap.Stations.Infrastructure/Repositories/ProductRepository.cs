using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using TankTap.Stations.Domain.ProductAggregate;
using TankTap.Stations.Infrastructure.Persistence;

namespace TankTap.Stations.Infrastructure.Repositories;

public class ProductRepository(DataContext dataContext) : IProductRepository
{
    private readonly DataContext _dataContext = dataContext;

    public async Task<List<Product>> GetProductsByIdsAsync(int[] ids, CancellationToken cancellationToken = default) 
        => await _dataContext.Products.Where(e => ids.Contains(e.Id)).ToListAsync();
}
