using FluentValidation;
using TankTap.Admistration.Application.Constants;
using TankTap.Admistration.Domain.CityAggregate;
using TankTap.Admistration.Domain.StationAggregate;

namespace TankTap.Admistration.Application.Stations.Add;

public class AddStationCommandValidator : AbstractValidator<AddStationCommand>
{
	private readonly IStationRepository _stationRepository;
	private readonly ICityRepository _cityRepository;

	public AddStationCommandValidator(IStationRepository stationRepository, ICityRepository cityRepository)
	{
		_stationRepository = stationRepository;
		_cityRepository = cityRepository;

		RuleFor(e => e.CityId)
			.MustAsync((e, cancellationToken) => IsCityExists(e, cancellationToken))
			.WithMessage(e => $"Entity City ({e.CityId}) was not found.");

		RuleFor(e => e.StationCode)
			.MustAsync((e, cancellationToken) => IsStationCodeExistsBefore(e, cancellationToken))
			.WithMessage(MessagesAr.StationCodeIsExist);

		RuleFor(e => e.StationERPCode)
			.MustAsync((e, cancellationToken) => IsStationERPCodeExistsBefore(e, cancellationToken))
			.WithMessage(MessagesAr.StationERDCodeIsExist);

		//RuleFor(e => e.PosInfo)
		//    .MustAsync((posInfo, cancellationToken)
		//    => POSDevicesNotExistsBefore(
		//        posInfo.Select(e => new POSDeviceModel
		//        {
		//            POSId = e.PosId,
		//            AndroidId = e.AndroidId
		//        }).ToArray(),
		//        cancellationToken));

	}

	private async Task<bool> IsCityExists(int id, CancellationToken cancellationToken = default)
		=> await _cityRepository.GetByIdAsync(id, cancellationToken) is not null;
	private async Task<bool> IsStationCodeExistsBefore(string code, CancellationToken cancellationToken = default)
		=> await _stationRepository.CheckIfStationCodeExistsBefore(code, cancellationToken);
	private async Task<bool> IsStationERPCodeExistsBefore(string erpCode, CancellationToken cancellationToken = default)
			=> await _stationRepository.CheckIfStationERPCodeExistsBefore(erpCode, cancellationToken);
	private async Task<bool> POSDevicesNotExistsBefore(POSDeviceModel[] posDevices, CancellationToken cancellationToken = default)
		=> !await _stationRepository.IsAnyPOSDevicesExists(posDevices, cancellationToken);
}
