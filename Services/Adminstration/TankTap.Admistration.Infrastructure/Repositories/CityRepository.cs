using Microsoft.EntityFrameworkCore;
using TankTap.Admistration.Domain.CityAggregate;
using TankTap.Admistration.Infrastructure.Persistence;

namespace TankTap.Admistration.Infrastructure.Repositories;

public class CityRepository(AdminstartionContext dataContext) : ICityRepository
{
	private readonly AdminstartionContext _dataContext = dataContext;

	public async Task<City?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
		=> await _dataContext.Cities.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
}
