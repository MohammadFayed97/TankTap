using TankTap.SharedKernel.Domain;

namespace TankTap.Admistration.Domain.ProductAggregate.Events;

public class ProductCreatedEvent(LocalizedName name, decimal price) : BaseDomainEvent
{
	public LocalizedName Name { get; } = name;
	public decimal Price { get; } = price;
}
