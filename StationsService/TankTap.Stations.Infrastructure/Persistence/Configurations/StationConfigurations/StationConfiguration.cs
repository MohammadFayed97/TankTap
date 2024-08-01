using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankTap.Stations.Domain.ProductAggregate;
using TankTap.Stations.Domain.StationAggregate;

namespace TankTap.Stations.Infrastructure.Persistence.Configurations.StationConfigurations
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.Ignore(e => e.Events);

            builder.ToTable(TankTabDbContextSchema.StationSchema.TableName);

            builder.HasKey(t => t.Id);
            
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Code).IsRequired();
            builder.Property(e => e.ERPCode).IsRequired();

            builder.OwnsOne(e => e.Distination, ownedBuilder =>
            {
                ownedBuilder
                    .Property(e => e.Latitude)
                    .HasColumnName(TankTabDbContextSchema.StationSchema.Latitude)
                    .IsRequired(false);
                ownedBuilder
                    .Property(e => e.Longitude)
                    .HasColumnName(TankTabDbContextSchema.StationSchema.Longitude)
                    .IsRequired(false);
            });

            builder.OwnsOne(e => e.Address, ownedBuilder =>
            {
                ownedBuilder
                    .HasOne(e => e.City)
                    .WithMany()
                    .HasForeignKey(TankTabDbContextSchema.StationSchema.CityIdForgienKey)
                    .HasConstraintName(TankTabDbContextSchema.StationSchema.CityForgienKeyConstrain)
                    .OnDelete(DeleteBehavior.NoAction);

                ownedBuilder
                    .Property(e => e.District)
                    .HasColumnName(TankTabDbContextSchema.StationSchema.District)
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
                ownedBuilder.ToTable(TankTabDbContextSchema.StationSchema.POSTableName);

                ownedBuilder.Property(e => e.Ip).IsRequired();
                ownedBuilder.Property(e => e.AndroidId).IsRequired();
                ownedBuilder.HasOne(e => e.Type)
                    .WithMany()
                    .HasForeignKey(TankTabDbContextSchema.StationSchema.POSTypeForginKey)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Navigation(e => e.PointOfSales).HasField(TankTabDbContextSchema.StationSchema.POSTypeBackendField);
            
            builder.Ignore(e => e.Pumps);
            builder.Ignore(e => e.Products);
        }
    }
}
