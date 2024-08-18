using Autofac;
using MediatR;
using TankTap.SharedKernel.Application.Contracts;

namespace TankTap.Invoices.Infrastructure.Configurations.Processing
{
	internal static class CommandsExecutor
	{
		internal static async Task Execute(ICommand command)
		{
			using var scope = InvoicesCompositionRoot.CreateScope();
			var mediator = scope.Resolve<IMediator>();

			await mediator.Send(command);
		}

		internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
		{
			using var scope = InvoicesCompositionRoot.CreateScope();
			var mediator = scope.Resolve<IMediator>();

			return await mediator.Send(command);
		}
	}
}
