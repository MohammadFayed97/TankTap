using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Invoices.Domain.StationAggregate;
using TankTap.SharedKernel.Infrastructure.DataAccess;

namespace TankTap.Invoices.Infrastructure.Persistence.Configurations.StationConfigurations;

internal class StationConfiguration : EntityConfigurationBase<Station, int>
{
    public override void Configure(EntityTypeBuilder<Station> builder)
    {
        base.Configure(builder);

        builder.ToTable(InvoicesDbContextSchema.Station.TableName);
        builder.Property(e => e.Name).IsRequired();
    }
}