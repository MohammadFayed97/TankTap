using TankTap.SharedKernel.Domain;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Admistration.IntegrationEvents;

public class ProductCreatedIntegrationEvent(
	Guid id,
	DateTime creationDate,
	LocalizedName productName,
	decimal price) : IntegrationEvent(id, creationDate)
{
	public LocalizedName ProductName { get; } = productName;
	public decimal Price { get; } = price;
}
