using Serilog;
using Serilog.Formatting.Compact;

namespace TankTap.API;

public static class DependencyInjection
{
	public static IServiceCollection ConfigureCors(this IServiceCollection services)
	{
		services.AddCors(options =>
		{
			options.AddPolicy(name: "AllowOrigin",
				builder =>
				{
					builder.AllowAnyOrigin()
						   .AllowAnyHeader()
						   .AllowAnyMethod();
				});
		});

		return services;
	}
	public static IServiceCollection ConfigureLogger(this IServiceCollection services)
	{
			var logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.WriteTo.Console(
					outputTemplate:
					"[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
				.WriteTo.File(new CompactJsonFormatter(), "logs/logs")
				.CreateLogger();

			logger.ForContext("Module", "API");

			logger.Information("Logger configured");

		services.AddSerilog(logger);

		return services;
	}
}
