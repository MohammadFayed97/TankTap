using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TankTap.Admistration.Infrastructure.Persistence;
public class AdministrationDbContextFactory() : IDesignTimeDbContextFactory<AdminstartionContext>
{
	public AdminstartionContext CreateDbContext(string[] args)
	{
		var connectionString = args.Length > 0 ? args[0] : "data source=(localdb)\\MSSQLLocalDB;initial catalog=TankTap;TrustServerCertificate=True;Trusted_Connection=True;";
		var optionBuilder = new DbContextOptionsBuilder<AdminstartionContext>();
		optionBuilder.UseSqlServer(
			connectionString,
			sqlOptions => sqlOptions
				.MigrationsAssembly(typeof(AdminstartionContext).Assembly.FullName)
				.MigrationsHistoryTable(
				tableName: HistoryRepository.DefaultTableName,
				schema: AdminstrationDbContextSchema.DefaultSchema));

		return new AdminstartionContext(optionBuilder.Options);
	}
}
