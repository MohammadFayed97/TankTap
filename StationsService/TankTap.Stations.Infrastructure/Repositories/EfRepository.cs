using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using TankTap.SharedKernel;
using TankTap.Stations.Infrastructure.Persistence;

namespace TankTap.Stations.Infrastructure.Repositories;

public class EfRepository<TEntity> : RepositoryBase<TEntity>, IRepositoryBase<TEntity> where TEntity : class, IAggregateRoot
{
    public EfRepository(DataContext dbContext) : base(dbContext) => Context = dbContext;

    public DataContext Context { get; }
}
