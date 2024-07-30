using Ardalis.Specification;

namespace TankTap.Stations.Domain.PointOfSaleTypeAggregate.Specifications;

public class GetPOSTypesListByIds : Specification<PointOfSaleType>
{
    public GetPOSTypesListByIds(int[] ids) => Query.Where(e => ids.Contains(e.Id));
}
