using Microsoft.Extensions.DependencyInjection;

namespace TankTap.SharedKernel.Infrastructure;

public interface IModule
{
	void RegisterServices(IServiceCollection services);
}