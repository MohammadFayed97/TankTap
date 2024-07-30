using Microsoft.AspNetCore.Diagnostics;
using TankTap.Stations.Application.Exceptions;
using TankTap.Stations.Domain.Results;

namespace TankTap.Stations.API.ErrorHandling;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) 
    : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

        var problemDetails = CreateProblemDetailFromException(exception);

        httpContext.Response.StatusCode = problemDetails.Status;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails.Result, cancellationToken);

        return true;
    }

    private static (Domain.Results.IResult Result, int Status) CreateProblemDetailFromException(Exception exception)
    {
        return exception is ValidationException
            ? (Result.Fail(exception.Message, [exception.Message]), StatusCodes.Status400BadRequest)
            : (Result.Fail("An Error Occured! please try again later.", ["Server error!"]), StatusCodes.Status500InternalServerError);
    }
}