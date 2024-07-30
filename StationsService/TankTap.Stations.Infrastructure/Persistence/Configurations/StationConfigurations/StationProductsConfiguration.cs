using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Stations.Domain.StationAggregate;
using TankTap.Stations.Infrastructure.Persistence;

public class StationProductsConfiguration : IEntityTypeConfiguration<StationProduct>
{
    public void Configure(EntityTypeBuilder<StationProduct> builder)
    {
        builder.Ignore(e => e.Events);

        builder.ToTable(TankTabDbContextSchema.StationSchema.StationProductsTableName);

        builder
            .HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.Price).IsRequired().HasPrecision(5);
    }
}
