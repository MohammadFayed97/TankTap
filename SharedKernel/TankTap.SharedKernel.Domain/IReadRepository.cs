using Ardalis.Specification;

namespace TankTap.SharedKernel.Domain;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}