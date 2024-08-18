using Autofac;
using Serilog;

namespace TankTap.Admistration.Infrastructure.Configurations;

internal class LoggingModule(ILogger logger) : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder
			.RegisterInstance(logger)
			.As<ILogger>()
			.SingleInstance();
	}
}

