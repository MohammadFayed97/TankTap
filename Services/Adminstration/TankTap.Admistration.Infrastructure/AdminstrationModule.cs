using TankTap.Admistration.Application;
using TankTap.Admistration.Infrastructure.Configurations.Processing;
using TankTap.SharedKernel.Application.Contracts;

namespace TankTap.Admistration.Infrastructure;

internal class AdminstrationModule : IAdminstrationModule
{
	public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command) 
		=> await CommandsExecutor.Execute(command);

	public async Task ExecuteCommandAsync(ICommand command) 
		=> await CommandsExecutor.Execute(command);
}
