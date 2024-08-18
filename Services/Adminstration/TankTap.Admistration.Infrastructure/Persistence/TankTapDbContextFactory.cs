using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TankTap.Admistration.Infrastructure.Persistence;
public class TankTapDbContextFactory() : IDesignTimeDbContextFactory<AdminstartionContext>
{
	public AdminstartionContext CreateDbContext(string[] args)
	{
		var optionBuilder = new DbContextOptionsBuilder<AdminstartionContext>();
		optionBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=TankTap;TrustServerCertificate=True;Trusted_Connection=True;");

		return new AdminstartionContext(optionBuilder.Options);
	}
}
