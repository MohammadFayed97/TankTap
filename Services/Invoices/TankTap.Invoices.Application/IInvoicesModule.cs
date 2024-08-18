using TankTap.SharedKernel.Application.Contracts;

namespace TankTap.Invoices.Application;

public interface IInvoicesModule
{
	Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

	Task ExecuteCommandAsync(ICommand command);

	//Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
