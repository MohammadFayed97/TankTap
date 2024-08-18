using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.SharedKernel.Application.Contracts;
using TankTap.SharedKernel.Domain;
using TankTap.SharedKernel.Domain.Results;
using TankTap.SharedKernel.Infrastructure;

namespace TankTap.Admistration.Application.Products.Add;

internal class AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : ICommandHandler<AddProductCommand, IResult>
{
	private readonly IProductRepository _productRepository = productRepository;

	public async Task<IResult> Handle(AddProductCommand command, CancellationToken cancellationToken)
	{
		var productName = new LocalizedName(command.ArName, command.EnName, command.UrName, command.BnName);
		var product = new Product(productName, command.Code, command.ERPCode, command.Price);

		await _productRepository.AddAsync(product, cancellationToken);
		await unitOfWork.CommitAsync(cancellationToken);

		return Result.Success();
	}
}