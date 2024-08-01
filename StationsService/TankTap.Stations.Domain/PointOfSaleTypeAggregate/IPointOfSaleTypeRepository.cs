namespace TankTap.Stations.Domain.PointOfSaleTypeAggregate;

public interface IPointOfSaleTypeRepository
{
    Task<List<PointOfSaleType>> GetPOSTypesListByIds(int[] ids, CancellationToken cancellationToken = default);
}