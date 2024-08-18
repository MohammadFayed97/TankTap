using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Admistration.Domain.StationAggregate;
using TankTap.Admistration.Infrastructure.Persistence;

namespace TankTap.Admistration.Infrastructure.Persistence.Configurations.StationConfigurations;

internal class PumpConfiguration : IEntityTypeConfiguration<Pump>
{
	public void Configure(EntityTypeBuilder<Pump> builder)
	{
		builder.Ignore(e => e.Events);

		builder.ToTable(AdminstrationDbContextSchema.StationSchema.PumpTableName);

		builder.HasKey(e => e.Id);

		builder.Property(e => e.Code).IsRequired();
		builder.Property(e => e.ERPCode).IsRequired();
	}
}