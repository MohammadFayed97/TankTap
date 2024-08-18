using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TankTap.Invoices.Domain.ProductAggregate;
using TankTap.Invoices.Domain.StationAggregate;
using TankTap.Invoices.Infrastructure.Persistence;
using TankTap.Invoices.Infrastructure.Persistence.Configurations.ProductConfigurations;
using TankTap.Invoices.Infrastructure.Persistence.Configurations.StationConfigurations;

namespace TankTap.Invoices.Infrastructure;

public class InvoicesContext(DbContextOptions<InvoicesContext> options) : DbContext(options)
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(InvoicesDbContextSchema.DefaultSchema);

		modelBuilder.ApplyConfiguration(new StationConfiguration());
		modelBuilder.ApplyConfiguration(new ProductConfiguration());
		
		base.OnModelCreating(modelBuilder);
	}
	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		int result = await base.SaveChangesAsync(true, cancellationToken).ConfigureAwait(false);

		return result;
	}
	public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();

	public DbSet<Station> Stations { get; set; }
	public DbSet<Product> Products { get; set; }
}
public class InvoicesDbContextFactory() : IDesignTimeDbContextFactory<InvoicesContext>
{
	public InvoicesContext CreateDbContext(string[] args)
	{
		var optionBuilder = new DbContextOptionsBuilder<InvoicesContext>();
		optionBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=TankTap;TrustServerCertificate=True;Trusted_Connection=True;");

		return new InvoicesContext(optionBuilder.Options);
	}
}
