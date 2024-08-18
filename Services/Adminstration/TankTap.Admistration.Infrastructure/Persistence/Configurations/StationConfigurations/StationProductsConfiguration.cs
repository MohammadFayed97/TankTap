using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Admistration.Domain.StationAggregate;

namespace TankTap.Admistration.Infrastructure.Persistence.Configurations.StationConfigurations;

public class StationProductsConfiguration : IEntityTypeConfiguration<StationProduct>
{
	public void Configure(EntityTypeBuilder<StationProduct> builder)
	{
		builder.Ignore(e => e.Events);

		builder.ToTable(AdminstrationDbContextSchema.StationSchema.StationProductsTableName);

		builder
			.HasOne(e => e.Product)
			.WithMany()
			.HasForeignKey(e => e.ProductId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(e => e.Price).IsRequired().HasPrecision(5);
	}
}