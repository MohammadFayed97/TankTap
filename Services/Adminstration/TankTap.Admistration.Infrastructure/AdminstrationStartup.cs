using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TankTap.SharedKernel.Infrastructure;
using TankTap.Admistration.Infrastructure.Configurations;
using TankTap.Admistration.Infrastructure.Configurations.Processing;
using TankTap.SharedKernel.Infrastructure.EventBus;
using TankTap.Admistration.Infrastructure.Configurations.EventBus;
using Autofac;
using TankTap.Admistration.Application;

namespace TankTap.Admistration.Infrastructure;

public static class AdminstrationStartup
{
	public static void Initialize(string connectionString, ILogger logger, IEventBus eventBus)
	{
		var moduleLogger = logger.ForContext("Module", "Administration");

		ConfigureContainer(connectionString, moduleLogger, eventBus);

		EventBusStartup.Initialize();
	}
	public static IServiceCollection AddAdminstrationModule(this IServiceCollection services) 
		=> services.AddScoped<IAdminstrationModule, AdminstrationModule>();


	private static void ConfigureContainer(string connectionString, ILogger logger, IEventBus eventBus)
	{
		var builder = new ContainerBuilder();

		builder.RegisterModule(new LoggingModule(logger));
		builder.RegisterModule(new DataAccessModule(connectionString));
		builder.RegisterModule(new MediatorModule());
		builder.RegisterModule(new ProcessingModule());
		builder.RegisterModule(new EventBusModule(eventBus));

		var container = builder.Build();

		AdministrationCompositionRoot.SetContainer(container);
	}
}
