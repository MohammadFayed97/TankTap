using FluentValidation;
using TankTap.SharedKernel;
using TankTap.Stations.Application.Constants;
using TankTap.Stations.Domain.CityAggregate;
using TankTap.Stations.Domain.StationAggregate;
using TankTap.Stations.Domain.StationAggregate.Specifications;

namespace TankTap.Stations.Application.Stations.Add;

public class AddStationCommandValidator : AbstractValidator<AddStationCommand>
{
    private readonly IStationRepository _stationRepository;
    private readonly IRepository<City> _cityRepository;

    public AddStationCommandValidator(IStationRepository stationRepository, IRepository<City> cityRepository)
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

        RuleFor(e => e.PosInfo)
            .MustAsync((posInfo, cancellationToken)
            => POSDevicesNotExistsBefore(
                posInfo.Select(e => new POSDeviceModel
                {
                    POSId = e.PosId,
                    AndroidId = e.AndroidId
                }).ToArray(),
                cancellationToken));

    }

    private async Task<bool> IsCityExists(int id, CancellationToken cancellationToken = default)
        => (await _cityRepository.GetByIdAsync(id, cancellationToken)) is not null;
    private async Task<bool> IsStationCodeExistsBefore(string code, CancellationToken cancellationToken = default)
        => await _stationRepository.AnyAsync(new CheckIfStationCodeExistsBeforeSpec(code), cancellationToken);
    private async Task<bool> IsStationERPCodeExistsBefore(string erpCode, CancellationToken cancellationToken = default)
            => await _stationRepository.AnyAsync(new CheckIfStationERPCodeExistsBeforeSpec(erpCode), cancellationToken);
    private async Task<bool> POSDevicesNotExistsBefore(POSDeviceModel[] posDevices, CancellationToken cancellationToken = default)
        => !(await _stationRepository.IsAnyPOSDevicesExists(posDevices, cancellationToken));
}
