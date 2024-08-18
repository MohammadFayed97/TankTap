namespace TankTap.SharedKernel.Infrastructure;

public interface IUnitOfWork
{
	Task CommitAsync(CancellationToken cancellationToken = default);
}