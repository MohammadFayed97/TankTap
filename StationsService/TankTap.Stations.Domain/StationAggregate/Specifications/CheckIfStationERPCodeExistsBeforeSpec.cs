using Ardalis.Specification;

namespace TankTap.Stations.Domain.StationAggregate.Specifications;

public class CheckIfStationERPCodeExistsBeforeSpec : Specification<Station>
{
    public CheckIfStationERPCodeExistsBeforeSpec(string erpCode)
        => Query.Where(e => e.ERPCode == erpCode);
}
