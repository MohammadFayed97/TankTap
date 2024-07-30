using Ardalis.Specification;

namespace TankTap.Stations.Domain.ProductAggregate.Specifications;

public class GetProductsByIdsSpec : Specification<Product>
{
    public GetProductsByIdsSpec(int[] ids) 
        => Query.Where(e => ids.Any(p => p == e.Id));
}
