using Ardalis.Specification;

namespace TankTap.Stations.Domain.StationAggregate.Specifications;

public class CheckIfStationCodeExistsBeforeSpec : Specification<Station>
{
    public CheckIfStationCodeExistsBeforeSpec(string code) 
        => Query.Where(e => e.Code == code);
}
