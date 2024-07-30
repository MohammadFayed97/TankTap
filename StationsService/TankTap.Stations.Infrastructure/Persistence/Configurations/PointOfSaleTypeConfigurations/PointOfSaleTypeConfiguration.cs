using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Stations.Domain;
using TankTap.Stations.Domain.PointOfSaleTypeAggregate;

namespace TankTap.Stations.Infrastructure.Persistence.Configurations.PointOfSaleTypeConfigurations;

public class PointOfSaleTypeConfiguration : IEntityTypeConfiguration<PointOfSaleType>
{
    public void Configure(EntityTypeBuilder<PointOfSaleType> builder)
    {
        builder.Ignore(e => e.Events);

        builder.ToTable(TankTabDbContextSchema.PointOfSaleTypeSchema.TableName);

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
