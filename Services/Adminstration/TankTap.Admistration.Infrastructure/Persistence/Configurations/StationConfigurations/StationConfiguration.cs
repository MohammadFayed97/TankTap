using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Admistration.Domain.StationAggregate;
using TankTap.SharedKernel.Infrastructure.DataAccess;

namespace TankTap.Admistration.Infrastructure.Persistence.Configurations.StationConfigurations;

public class StationConfiguration : EntityConfigurationBase<Station, int>
{
	public override void Configure(EntityTypeBuilder<Station> builder)
	{
		base.Configure(builder);

		builder.ToTable(AdminstrationDbContextSchema.StationSchema.TableName);

		builder.Property(e => e.Name).IsRequired();
		builder.Property(e => e.Code).IsRequired();
		builder.Property(e => e.ERPCode).IsRequired();

		builder.OwnsOne(e => e.Distination, ownedBuilder =>
		{
			ownedBuilder
				.Property(e => e.Latitude)
				.HasColumnName(AdminstrationDbContextSchema.StationSchema.Latitude)
				.IsRequired(false);
			ownedBuilder
				.Property(e => e.Longitude)
				.HasColumnName(AdminstrationDbContextSchema.StationSchema.Longitude)
				.IsRequired(false);
		});

		builder.OwnsOne(e => e.Address, ownedBuilder =>
		{
			ownedBuilder
				.HasOne(e => e.City)
				.WithMany()
				.HasForeignKey(AdminstrationDbContextSchema.StationSchema.CityIdForgienKey)
				.HasConstraintName(AdminstrationDbContextSchema.StationSchema.CityForgienKeyConstrain)
				.OnDelete(DeleteBehavior.NoAction);

			ownedBuilder
				.Property(e => e.District)
				.HasColumnName(AdminstrationDbContextSchema.StationSchema.District)
				.IsRequired();
		});

		builder
			.HasMany(e => e.Tanks)
			.WithOne()
			.HasForeignKey(e => e.StationId)
			.OnDelete(DeleteBehavior.Cascade);

		builder
			.HasMany(e => e.StationProducts)
			.WithOne()
			.HasForeignKey(e => e.StationId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.OwnsMany(e => e.PointOfSales, ownedBuilder =>
		{
			ownedBuilder.ToTable(AdminstrationDbContextSchema.StationSchema.POSTableName);

			ownedBuilder.Property(e => e.Ip).IsRequired();
			ownedBuilder.Property(e => e.AndroidId).IsRequired();
			ownedBuilder.HasOne(e => e.Type)
				.WithMany()
				.HasForeignKey(AdminstrationDbContextSchema.StationSchema.POSTypeForginKey)
				.OnDelete(DeleteBehavior.NoAction);
		});

		builder.Navigation(e => e.PointOfSales).HasField(AdminstrationDbContextSchema.StationSchema.POSTypeBackendField);

		builder.Ignore(e => e.Pumps);
		builder.Ignore(e => e.Products);
	}
}
