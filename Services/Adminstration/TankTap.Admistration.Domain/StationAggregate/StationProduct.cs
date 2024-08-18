using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.StationAggregate;

public sealed class StationProduct : Entity<int>
{
    public int StationId { get; }
    public int ProductId { get; }
    public Product Product { get; }
    public decimal Price { get; }

    public StationProduct(int stationId, Product product, decimal stationPrice)
    {
        StationId = stationId;
        ProductId = product.Id;
        Product = product;
        Price = stationPrice;
    }
    private StationProduct() { } // EF
}
