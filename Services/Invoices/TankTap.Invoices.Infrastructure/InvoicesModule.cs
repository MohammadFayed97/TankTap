using TankTap.Invoices.Application;
using TankTap.Invoices.Infrastructure.Configurations.Processing;
using TankTap.SharedKernel.Application.Contracts;

namespace TankTap.Invoices.Infrastructure;

internal class InvoicesModule : IInvoicesModule
{
	public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
		=> await CommandsExecutor.Execute(command);

	public async Task ExecuteCommandAsync(ICommand command)
		=> await CommandsExecutor.Execute(command);
}
