using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TankTap.Invoices.Domain.ProductAggregate;
using TankTap.SharedKernel.Domain;
using TankTap.SharedKernel.Infrastructure.DataAccess;

namespace TankTap.Invoices.Infrastructure.Persistence.Configurations.ProductConfigurations;

internal class ProductConfiguration : EntityConfigurationBase<Product, int>
{
	public override void Configure(EntityTypeBuilder<Product> builder)
	{
		base.Configure(builder);

		builder.ToTable(InvoicesDbContextSchema.Product.TableName);

		builder.OwnsOne(e => e.Name, ownedbuilder =>
		{
			ownedbuilder.Property(e => e.ArName).HasColumnName(nameof(LocalizedName.ArName));
			ownedbuilder.Property(e => e.EnName).HasColumnName(nameof(LocalizedName.EnName));
			ownedbuilder.Property(e => e.UrName).HasColumnName(nameof(LocalizedName.UrName));
			ownedbuilder.Property(e => e.BnName).HasColumnName(nameof(LocalizedName.BnName));
		});
	}
}
