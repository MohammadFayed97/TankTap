using FluentValidation.AspNetCore;
using TankTap.SharedKernel;
using TankTap.Stations.API.ErrorHandling;
using TankTap.Stations.Application;
using TankTap.Stations.Infrastructure;
using TankTap.Stations.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddEnvironmentVariables();

builder.Services.RegisterApplicationLayer();
builder.Services.RegisterInfrastructureLayer(builder.Configuration);

builder.Services.AddControllers();
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(EfRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
