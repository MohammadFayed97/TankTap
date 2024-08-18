namespace TankTap.SharedKernel.Domain.Results;

public interface IResult
{

	string Message { get; }

	bool IsSuccess { get; }

	string[] Errors { get; }
}

public interface IResult<out T> : IResult
{
	T Data { get; }
}
