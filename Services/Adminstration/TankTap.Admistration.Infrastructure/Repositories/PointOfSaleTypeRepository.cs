using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using TankTap.Admistration.Domain.PointOfSaleTypeAggregate;
using TankTap.Admistration.Infrastructure.Persistence;

namespace TankTap.Admistration.Infrastructure.Repositories;

public class PointOfSaleTypeRepository(AdminstartionContext dataContext) : IPointOfSaleTypeRepository
{
	private readonly AdminstartionContext _dataContext = dataContext;

	public async Task<List<PointOfSaleType>> GetPOSTypesListByIds(int[] ids, CancellationToken cancellationToken = default)
		=> await _dataContext.PointOfSaleTypes
		.Where(e => ids.Contains(e.Id))
		.ToListAsync(cancellationToken);
}
