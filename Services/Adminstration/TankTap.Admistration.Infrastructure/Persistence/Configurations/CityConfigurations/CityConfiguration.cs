using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Admistration.Domain;
using TankTap.Admistration.Domain.CityAggregate;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Infrastructure.Persistence.Configurations.CityConfigurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
	public void Configure(EntityTypeBuilder<City> builder)
	{
		builder.Ignore(e => e.Events);

		builder.ToTable(AdminstrationDbContextSchema.CitySchema.TableName);

		builder.HasKey(e => e.Id);

		builder.OwnsOne(e => e.Name, ownedbuilder =>
		{
			ownedbuilder.Property(e => e.ArName).HasColumnName(nameof(LocalizedName.ArName));
			ownedbuilder.Property(e => e.EnName).HasColumnName(nameof(LocalizedName.EnName));
			ownedbuilder.Property(e => e.UrName).HasColumnName(nameof(LocalizedName.UrName));
			ownedbuilder.Property(e => e.BnName).HasColumnName(nameof(LocalizedName.BnName));
		});
	}
}
