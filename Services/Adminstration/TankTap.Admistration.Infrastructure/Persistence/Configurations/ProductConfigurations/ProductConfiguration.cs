using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Admistration.Domain;
using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Infrastructure.Persistence.Configurations.ProductConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.Ignore(e => e.Events);

		builder.ToTable(AdminstrationDbContextSchema.ProductSchema.TableName);

		builder.HasKey(e => e.Id);

		builder.OwnsOne(e => e.Name, ownedbuilder =>
		{
			ownedbuilder.Property(e => e.ArName).HasColumnName(nameof(LocalizedName.ArName));
			ownedbuilder.Property(e => e.EnName).HasColumnName(nameof(LocalizedName.EnName));
			ownedbuilder.Property(e => e.UrName).HasColumnName(nameof(LocalizedName.UrName));
			ownedbuilder.Property(e => e.BnName).HasColumnName(nameof(LocalizedName.BnName));
		});
		builder.Property(e => e.Code).IsRequired();
		builder.Property(e => e.ERPCode).IsRequired();
	}
}
