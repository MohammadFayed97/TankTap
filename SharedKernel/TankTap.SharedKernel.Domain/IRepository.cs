using Ardalis.Specification;

namespace TankTap.SharedKernel.Domain;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}