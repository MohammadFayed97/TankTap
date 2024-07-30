using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Stations.Domain.StationAggregate;
using TankTap.Stations.Infrastructure.Persistence;

public class PumpConfiguration : IEntityTypeConfiguration<Pump>
{
    public void Configure(EntityTypeBuilder<Pump> builder)
    {
        builder.Ignore(e => e.Events);

        builder.ToTable(TankTabDbContextSchema.StationSchema.PumpTableName);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).IsRequired();
        builder.Property(e => e.ERPCode).IsRequired();
    }
}
