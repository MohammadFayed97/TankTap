using TankTap.Admistration.IntegrationEvents;
using TankTap.Invoices.Domain.ProductAggregate;
using TankTap.SharedKernel.Infrastructure;
using TankTap.SharedKernel.Infrastructure.EventBus;

namespace TankTap.Invoices.Application.Stations;

public class ProductCreatedIntegrationEventHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) 
	: IIntegrationEventHandler<ProductCreatedIntegrationEvent>
{
	private readonly IProductRepository _productRepository = productRepository;
	private readonly IUnitOfWork _unitOfWork = unitOfWork;

	public async Task HandleAsync(ProductCreatedIntegrationEvent @event)
	{
		var newProduct = new Product(@event.ProductName, @event.Price);
		
		await _productRepository.AddAsync(newProduct);
		await _unitOfWork.CommitAsync();
	}
}
