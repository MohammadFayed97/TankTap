using TankTap.Admistration.Application.Constants;
using TankTap.Admistration.Domain.CityAggregate;
using TankTap.Admistration.Domain.PointOfSaleTypeAggregate;
using TankTap.Admistration.Domain.ProductAggregate;
using TankTap.Admistration.Domain.StationAggregate;
using TankTap.SharedKernel.Application.Contracts;
using TankTap.SharedKernel.Domain.Results;
using TankTap.SharedKernel.Infrastructure;
using static TankTap.Admistration.Application.Stations.Add.AddStationCommand;

namespace TankTap.Admistration.Application.Stations.Add;

internal class AddStationCommandHandler : ICommandHandler<AddStationCommand, IResult>
{
	private readonly IStationRepository _stationRepository;
	private readonly ICityRepository _cityRepository;
	private readonly IProductRepository _productRepository;
	private readonly IPointOfSaleTypeRepository _posTypeRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddStationCommandHandler(
			IStationRepository stationRepository,
			ICityRepository cityRepository,
			IProductRepository productRepository,
			IPointOfSaleTypeRepository posTypeRepository,
			IUnitOfWork unitOfWork)
	{
		_stationRepository = stationRepository;
		_cityRepository = cityRepository;
		_productRepository = productRepository;
		_posTypeRepository = posTypeRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<IResult> Handle(AddStationCommand request, CancellationToken cancellationToken)
	{
		City? city = await _cityRepository.GetByIdAsync(request.CityId, cancellationToken);
		if (city is null)
			return Result.NotFound(nameof(city), request.CityId);

		var posDevicesExtractionResult = await TryGetPOSDevicesToAdd(request.PosInfo!);
		if (!posDevicesExtractionResult.IsSuccess)
			return Result.Fail(posDevicesExtractionResult.Message);

		var address = new StationAddress(city, request.District);
		IResult<Station> result = Station.Create(request.StationName, request.StationCode, request.StationERPCode, address);
		if (!result.IsSuccess)
			return result;

		Station station = result.Data;
		station.AddPOS(posDevicesExtractionResult.Data);

		var productsExtractionResult = await TryGetSelectedProductsWithNewPrice(request.PricesInfo, cancellationToken);
		if (!productsExtractionResult.IsSuccess)
			return Result.Fail(productsExtractionResult.Message);

		station.AddProducts(productsExtractionResult.Data);

		AddTanks(station, request.TanksInfo, AddPumps(request.PumpsInfo));

		await _stationRepository.AddAsync(station, cancellationToken);

		await _unitOfWork.CommitAsync(cancellationToken);

		return await Result.SuccessAsync();
	}

	private async Task<IResult<POSDevice[]>> TryGetPOSDevicesToAdd(List<PointOfSaleDevice> posDevices)
	{
		var selectedPosTypesIds = posDevices.Select(e => e.LKPointOfSaleId).ToArray();
		var posTypes = await _posTypeRepository.GetPOSTypesListByIds(selectedPosTypesIds);
		if (posTypes.Count != selectedPosTypesIds.Length)
			return Result<POSDevice[]>.Fail("POS Type not found.");

		var posTypesDictionary = posTypes.ToDictionary(e => e.Id);
		var posDevicesToAdd = posDevices
			.Select(e => new POSDevice(e.PosId, e.AndroidId, posTypesDictionary[e.LKPointOfSaleId]))
			.ToArray();

		return Result<POSDevice[]>.Success(posDevicesToAdd);
	}

	private async Task<IResult<Dictionary<Product, decimal>>> TryGetSelectedProductsWithNewPrice(List<PriceInfo> priceInfos, CancellationToken cancellationToken = default)
	{
		var selectedProductsDictionary = priceInfos.ToDictionary(e => e.LKProductId, e => e.Price);
		int[] selectedProductIds = priceInfos.Select(e => e.LKProductId).ToArray();
		List<Product> selectedProducts = await _productRepository.GetProductsByIdsAsync(selectedProductIds, cancellationToken);

		if (selectedProducts.Count != selectedProductIds.Length)
			return Result<Dictionary<Product, decimal>>.Fail(MessagesAr.ProductNotFount);

		var productsToAdd = selectedProducts
			.ToDictionary(product => product, product => selectedProductsDictionary[product.Id]);

		return Result<Dictionary<Product, decimal>>.Success(productsToAdd);
	}
	private void AddTanks(Station station, List<TankInfo> tankInfos, Action<Tank> postAddTankAction)
	{
		Dictionary<int, Product> products = station.Products.ToDictionary(e => e.Id, product => product);

		foreach (var tankInfo in tankInfos)
		{
			Product product = products[tankInfo.LKProductId];
			Tank tank = station.AddTank(tankInfo.Code, tankInfo.Capacity, product);

			postAddTankAction.Invoke(tank);
		}
	}
	private Action<Tank> AddPumps(List<PumpInfo> pumps)
	{
		var pumpsToAddAsDictionary = pumps.ToDictionary(e => e.TankCode, pump => pump);

		Action<Tank> addPumpAction = tank =>
		{
			if (!pumpsToAddAsDictionary.TryGetValue(tank.Code, out var pump))
				return;

			tank.AddPump(pump.Code, pump.ERPCode);
		};

		return addPumpAction;
	}
}