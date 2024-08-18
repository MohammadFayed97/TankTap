using Microsoft.EntityFrameworkCore;
using TankTap.Admistration.Domain.CityAggregate;
using TankTap.Admistration.Domain.PointOfSaleTypeAggregate;
using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.Admistration.Domain.RegionAggregate;
using TankTap.Admistration.Domain.StationAggregate;

namespace TankTap.Admistration.Infrastructure.Persistence;

public class AdminstartionContext(DbContextOptions<AdminstartionContext> options) : DbContext(options)
{

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(AdminstrationDbContextSchema.DefaultSchema);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdminstartionContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		int result = await base.SaveChangesAsync(true, cancellationToken).ConfigureAwait(false);

		return result;
	}
	public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();

	public DbSet<Region> Regions { get; set; }
	public DbSet<City> Cities { get; set; }
	public DbSet<PointOfSaleType> PointOfSaleTypes { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Station> Stations { get; set; }
}
