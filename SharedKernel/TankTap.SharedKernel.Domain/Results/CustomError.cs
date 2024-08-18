namespace TankTap.SharedKernel.Domain.Results;

public class CustomError(string code, string description)
{
	public string Code { get; } = code;
	public string Description { get; } = description;
}