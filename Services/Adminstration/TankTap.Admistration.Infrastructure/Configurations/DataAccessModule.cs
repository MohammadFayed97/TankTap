using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TankTap.Admistration.Infrastructure.Persistence;

namespace TankTap.Admistration.Infrastructure.Configurations;

internal class DataAccessModule(string connectionString) : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		var infrastructureAssembly = typeof(AdminstartionContext).Assembly;

		builder
			.Register(c =>
			{
				var dbContextOptionsBuilder = new DbContextOptionsBuilder<AdminstartionContext>();
				dbContextOptionsBuilder.UseSqlServer(
					connectionString, 
					sqlOptions => sqlOptions
					.MigrationsAssembly(typeof(AdminstartionContext).Assembly.FullName)
					.MigrationsHistoryTable(
					tableName: HistoryRepository.DefaultTableName,
					schema: AdminstrationDbContextSchema.DefaultSchema));

				//dbContextOptionsBuilder
				//	.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

				return new AdminstartionContext(dbContextOptionsBuilder.Options);
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