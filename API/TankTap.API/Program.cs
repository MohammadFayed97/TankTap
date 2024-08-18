using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Compact;
using TankTap.Admistration.Infrastructure;
using TankTap.API;
using TankTap.Invoices.Infrastructure;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var logger = CreateLogger();
var apiLogger = logger.ForContext("Module", "API");

builder.Host.UseSerilog(logger: apiLogger);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddAdminstrationModule();
builder.Services.AddInvoicesModule();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors();

var app = builder.Build();

var container = app.Services.GetAutofacRoot();
InitializeModule(container);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();


void InitializeModule(ILifetimeScope container)
{
	string? connectionString = builder.Configuration.GetConnectionString("TankTapContext");
	ArgumentException.ThrowIfNullOrEmpty(connectionString);

	AdminstrationStartup.Initialize(connectionString, logger, null!);
	InvoicesStartup.Initialize(connectionString, logger, null!);
}

ILogger CreateLogger()
{
	var logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.WriteTo.Console(
					outputTemplate:
					"[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
				.WriteTo.File(new CompactJsonFormatter(), "logs/logs")
				.CreateLogger();

	logger.Information("Logger configured");

	return logger;
}