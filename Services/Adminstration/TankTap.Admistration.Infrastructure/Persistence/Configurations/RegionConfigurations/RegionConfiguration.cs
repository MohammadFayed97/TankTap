using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Admistration.Domain;
using TankTap.Admistration.Domain.RegionAggregate;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Infrastructure.Persistence.Configurations.RegionConfigurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
	public void Configure(EntityTypeBuilder<Region> builder)
	{
		builder.Ignore(e => e.Events);

		builder.ToTable(AdminstrationDbContextSchema.RegionSchema.TableName);

		builder.HasKey(e => e.Id);

		builder.OwnsOne(e => e.Name, ownedbuilder =>
		{
			ownedbuilder.Property(e => e.ArName).HasColumnName(nameof(LocalizedName.ArName));
			ownedbuilder.Property(e => e.EnName).HasColumnName(nameof(LocalizedName.EnName));
			ownedbuilder.Property(e => e.UrName).HasColumnName(nameof(LocalizedName.UrName));
			ownedbuilder.Property(e => e.BnName).HasColumnName(nameof(LocalizedName.BnName));
		});

		builder
			.HasMany(e => e.Cities)
			.WithOne()
			.HasForeignKey(e => e.RegionId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
