using MediatR;

namespace TankTap.SharedKernel.Infrastructure.DomainEventDispatching;

internal class DomainEventDispatcher(IMediator mediator, IDomainEventAccessor domainEventAccessor) : IDomainEventDispatcher
{
	private readonly IMediator _mediator = mediator;
	private readonly IDomainEventAccessor _domainEventAccessor = domainEventAccessor;

	public async Task DispatchAsync(CancellationToken cancellationToken = default)
	{
		var domainEvents = _domainEventAccessor.GetAllDomainEvents();

		_domainEventAccessor.ClearAllDomainEvents();

		foreach (var domainEvent in domainEvents)
		{
			await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
		}
	}
}
