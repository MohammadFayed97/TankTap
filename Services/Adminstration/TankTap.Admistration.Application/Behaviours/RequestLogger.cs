using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace TankTap.Admistration.Application.Behaviours;

public class RequestLogger<TRequest>(ILogger<TRequest> logger) : IRequestPreProcessor<TRequest>
	where TRequest : notnull
{
	private readonly ILogger _logger = logger;

	public Task Process(TRequest request, CancellationToken cancellationToken)
	{
		var name = typeof(TRequest).Name;

		_logger.LogInformation("TankTap Service Request: {Name} {@Request}",
			name, request);

		return Task.CompletedTask;
	}
}
