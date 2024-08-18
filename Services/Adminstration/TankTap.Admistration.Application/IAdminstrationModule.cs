using TankTap.SharedKernel.Application.Contracts;

namespace TankTap.Admistration.Application;

public interface IAdminstrationModule
{
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

    Task ExecuteCommandAsync(ICommand command);

    //Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}

