using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using TankTap.Invoices.Infrastructure.Persistence;

namespace TankTap.Invoices.Infrastructure;

public class InvoicesDbContextFactory : IDesignTimeDbContextFactory<InvoicesContext>
{
	public InvoicesContext CreateDbContext(string[] args)
	{
		var connectionString = args.Length > 0 ? args[0] : "data source=(localdb)\\MSSQLLocalDB;initial catalog=TankTap;TrustServerCertificate=True;Trusted_Connection=True;";
		var optionBuilder = new DbContextOptionsBuilder<InvoicesContext>();
		optionBuilder.UseSqlServer(
			connectionString,
			sqlOptions => sqlOptions
				.MigrationsAssembly(typeof(InvoicesContext).Assembly.FullName)
				.MigrationsHistoryTable(
				tableName: HistoryRepository.DefaultTableName,
				schema: InvoicesDbContextSchema.DefaultSchema));

		return new InvoicesContext(optionBuilder.Options);
	}
}
