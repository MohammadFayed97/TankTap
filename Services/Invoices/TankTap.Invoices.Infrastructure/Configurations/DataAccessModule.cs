using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TankTap.Invoices.Infrastructure;
using TankTap.Invoices.Infrastructure.Configurations;
using TankTap.Invoices.Infrastructure.Persistence;

namespace TankTap.Admistration.Infrastructure.Configurations;

internal class DataAccessModule(string connectionString) : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		var infrastructureAssembly = typeof(InvoicesContext).Assembly;

		builder
			.Register(c =>
			{
				var dbContextOptionsBuilder = new DbContextOptionsBuilder<InvoicesContext>();
				dbContextOptionsBuilder.UseSqlServer(
					connectionString, 
					sqlOptions => sqlOptions
					.MigrationsAssembly(infrastructureAssembly.FullName)
					.MigrationsHistoryTable(
					tableName: HistoryRepository.DefaultTableName,
					schema: InvoicesDbContextSchema.DefaultSchema));

				//dbContextOptionsBuilder
				//	.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

				return new InvoicesContext(dbContextOptionsBuilder.Options);
			})
			.AsSelf()
			.As<DbContext>()
			.InstancePerLifetimeScope();

		builder.RegisterAssemblyTypes(infrastructureAssembly)
			.Where(type => type.Name.EndsWith("Repository"))
			.AsImplementedInterfaces()
			.InstancePerLifetimeScope()
			.FindConstructorsWith(new AllConstructorFinder());
	}
}