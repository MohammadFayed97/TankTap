using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Admistration.Domain.StationAggregate;

namespace TankTap.Admistration.Infrastructure.Persistence.Configurations.StationConfigurations;

internal class TankConfiguration : IEntityTypeConfiguration<Tank>
{
	public void Configure(EntityTypeBuilder<Tank> builder)
	{
		builder.Ignore(e => e.Events);

		builder.ToTable(AdminstrationDbContextSchema.StationSchema.TankTableName);

		builder.HasKey(e => e.Id);

		builder.Property(e => e.Code).IsRequired();
		builder.Property(e => e.Capacity).IsRequired();
		builder
			.HasOne(e => e.Product)
			.WithMany()
			.HasForeignKey(e => e.ProductId)
			.OnDelete(DeleteBehavior.NoAction);
		builder
			.HasMany(e => e.Pumps)
			.WithOne()
			.HasForeignKey(e => e.TankId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}