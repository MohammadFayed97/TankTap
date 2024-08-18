using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.SharedKernel.Domain;

namespace TankTap.SharedKernel.Infrastructure.DataAccess;

public abstract class EntityConfigurationBase<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
	where TEntity : Entity<TKey>
	where TKey : IEquatable<TKey>
{
	public virtual void Configure(EntityTypeBuilder<TEntity> builder)
	{
		builder.Ignore(e => e.Events);

		builder.HasKey(e => e.Id);
	}
}