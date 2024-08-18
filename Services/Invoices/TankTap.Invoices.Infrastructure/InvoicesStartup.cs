using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TankTap.SharedKernel.Infrastructure;
using TankTap.Admistration.Infrastructure.Configurations;
using TankTap.Admistration.Infrastructure.Configurations.Processing;
using TankTap.SharedKernel.Infrastructure.EventBus;
using Autofac;
using TankTap.Invoices.Infrastructure.Configurations.EventBus;
using TankTap.Invoices.Application;
using TankTap.Invoices.Infrastructure.Configurations;

namespace TankTap.Invoices.Infrastructure;

public static class InvoicesStartup
{
	public static void Initialize(string connectionString, ILogger logger, IEventBus eventBus)
	{
		var moduleLogger = logger.ForContext("Module", "Invoices");

		ConfigureContainer(connectionString, moduleLogger, eventBus);

		EventBusStartup.Initialize();
	}
	public static IServiceCollection AddInvoicesModule(this IServiceCollection services)
		=> services.AddScoped<IInvoicesModule, InvoicesModule>();


	private static void ConfigureContainer(string connectionString, ILogger logger, IEventBus eventBus)
	{
		var builder = new ContainerBuilder();

		builder.RegisterModule(new LoggingModule(logger));
		builder.RegisterModule(new DataAccessModule(connectionString));
		builder.RegisterModule(new MediatorModule());
		builder.RegisterModule(new ProcessingModule());
		builder.RegisterModule(new EventBusModule(eventBus));

		var container = builder.Build();

		InvoicesCompositionRoot.SetContainer(container);
	}
}
