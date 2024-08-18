using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TankTap.Admistration.Application.Behaviours;

public class RequestPerformanceBehaviour<TRequest, TResponse>(ILogger<TRequest> logger)
	: IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
	private readonly Stopwatch _timer = new Stopwatch();
	private readonly ILogger<TRequest> _logger = logger;

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		_timer.Start();

		var response = await next();

		_timer.Stop();

		if (_timer.ElapsedMilliseconds > 500)
		{
			var name = typeof(TRequest).Name;

			_logger.LogWarning("TankTap Service Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
				name, _timer.ElapsedMilliseconds, request);
		}
		var responseName = typeof(TResponse).Name;

		_logger.LogInformation("Loan Service Response: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
			responseName, _timer.ElapsedMilliseconds, response);

		return response;
	}
}
